using Auth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly AppDbContext _app;
        public MeetingController(AppDbContext context)
        {
            _app = context;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Meeting meeting)
        {
            _app.Meetings.Add(meeting);
            _app.SaveChanges();
            return Ok(meeting);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_app.Meetings.ToList());
        }
        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetDetails(Guid id)
        {
            return Ok(_app.Meetings.Find(id));

        }

        [HttpPatch("edit/{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] Meeting model)
        {
            var temp = _app.Meetings.Find(id);
            if(temp != null)
            {
                model.Id = temp.Id;
            }
            _app.Meetings.Update(model);
            _app.SaveChanges();
            return Ok(temp);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var temp = _app.Meetings.Find(id);
            _app.Meetings.Remove(temp);
            _app.SaveChanges();
            return Ok("DELETED");
        }

    }
}
