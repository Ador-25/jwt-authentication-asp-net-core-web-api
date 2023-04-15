using Auth.Models;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        AppDbContext _app;
        public MessageController(AppDbContext app)
        {
            _app = app;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_app.Messages.ToList());
        }
        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetDetails(Guid id)
        {
            return Ok(_app.Messages.Find(id));

        }
    }
}
