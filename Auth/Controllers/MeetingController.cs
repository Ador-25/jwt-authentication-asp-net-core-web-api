using Auth.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

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
        private void SendMail(string em,Meeting meeting)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("admin@ethereal.email"));
            email.To.Add(MailboxAddress.Parse(em));
            email.Subject = "Meet Link";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = "TIME: " + meeting.Time + "</br>"
                + "DATE: " + meeting.Date + "</br>" +
                "URL: " + meeting.MeetingUrl
            };
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, MailKit.Security.SecureSocketOptions.StartTls);
            var m = "vincent.schulist@ethereal.email";
            var p = "FHRZFVf5RevgassV9p";
            smtp.Authenticate(m, p);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MeetingPost meeting)
        {
            Meeting m = new Meeting();
            m.Id= Guid.NewGuid();
            m.Time = meeting.Time;
            m.Date= meeting.Date;
            m.MeetingUrl = meeting.MeetingUrl;
            _app.Meetings.Add(m);
            _app.SaveChanges();
            foreach(var mail in meeting.Emails)
            {
                SendMail(mail, m);
            }
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
