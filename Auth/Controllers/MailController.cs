using Auth.Models;
using Auth.Services;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService mailService;
        private readonly IEmailSender emailSender;
        public MailController(IMailService mailService,IEmailSender emailSender)
        {
            this.mailService = mailService;
            this.emailSender = emailSender;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] MailRequest request)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("admin@ethereal.email"));
                email.To.Add(MailboxAddress.Parse(request.ToEmail));
                email.Subject = "Meet Link";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = request.Body
                };
                using var smtp = new SmtpClient();
                smtp.Connect("smtp.ethereal.email", 587, MailKit.Security.SecureSocketOptions.StartTls);
                var m = "alford.mayer15@ethereal.email";
                var p = "FNYencKKFheWCdb1cE";
                smtp.Authenticate(m, p);
                smtp.Send(email);
                smtp.Disconnect(true);
                return Ok("DONE");

            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
