using Auth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth.Controllers
{
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _app;

        public AuthenticateController(UserManager<ApplicationUser> us
            ,RoleManager<IdentityRole> rl, AppDbContext app, IConfiguration configuration)
        {
            userManager = us;
            roleManager = rl;
            _app = app;
            _configuration = configuration;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Admin model)
        {
            Console.WriteLine(model);
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                var role = model.Username == "admin29@gmail.com" ? "Admin" : "User";
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    role = role // Add the user role to the response
                });
            }
            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] Patient model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            model.Password = "***************";
            _app.Patients.Add(model);
            _app.SaveChanges();

            try
            {
                var roleManager = HttpContext.RequestServices.GetService<RoleManager<IdentityRole>>();
                var roleName = "User";
                var roleExists = await roleManager.RoleExistsAsync(roleName);
                if (roleExists)
                {

                }
                else
                {
                    var role = new IdentityRole { Name = roleName };
                    var res = await roleManager.CreateAsync(role);
                    var userrole = await userManager.AddToRoleAsync(user, role.Name);
                }
            }
            catch (Exception ex)
            {

            }
            return Ok(new Response { Status = "Success", Message = "OTP Sent to Email Please confirm." });

        }




        [AllowAnonymous]
        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] Admin model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Username,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            try
            {
                var roleManager = HttpContext.RequestServices.GetService<RoleManager<IdentityRole>>();
                var roleName = "Admin";
                var roleExists = await roleManager.RoleExistsAsync(roleName);
                if (roleExists)
                {

                }
                else
                {
                    var role = new IdentityRole { Name = roleName };
                    var res = await roleManager.CreateAsync(role);
                    var userrole = await userManager.AddToRoleAsync(user, role.Name);
                }
            }
            catch (Exception ex)
            {

            }
            return Ok(new Response { Status = "Success", Message = "OTP Sent to Email Please confirm." });

        }
    }
}
