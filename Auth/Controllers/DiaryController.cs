using Auth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiaryController : ControllerBase
    {
        private readonly AppDbContext _app;
        public DiaryController(AppDbContext app)
        {
            _app = app;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Diary diary)
        {
            _app.Diaries.Add(diary);
            _app.SaveChanges();
            return Ok(diary);        
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_app.Diaries.ToList());
        }
        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetDetails(Guid id)
        {
            return Ok(_app.Diaries.Find(id));

        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] Diary model)
        {
            var temp = _app.Diaries.Find(id);
            temp.Medication = model.Medication;
            temp.YesOrNo = model.YesOrNo;
            temp.Action = model.Action;
            _app.Diaries.Update(temp);
            _app.SaveChanges();
            return Ok(temp);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var temp = _app.Diaries.Find(id);
            _app.Diaries.Remove(temp);
            _app.SaveChanges();
            return Ok("DELETED");
        }


    }
}
