using Auth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly AppDbContext _app;
        public PatientController(AppDbContext t)
        {
            _app = t;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Patient patient)
        {
            _app.Patients.Add(patient);
            _app.SaveChanges();
            patient.Password = "null";
            return Ok(patient);
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            return Ok(_app.Patients.ToList());
        }
        [HttpGet("total")]
        public async Task<IActionResult> GetTotal()
        {
            return Ok(_app.Patients.ToList().Count());
        }


        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetPatient(Guid id)
        {
            return Ok(_app.Patients.Find(id));
        }
        [HttpPost("edit/{id}")]
        public async Task<IActionResult> Edit(Guid id,[FromBody] Patient model)
        {
            var temp = _app.Patients.Find(id);
            temp.DateOfBirth = model.DateOfBirth;
            temp.ChildName = model.ChildName;
            temp.Father = model.Father;
            temp.Mother = model.Mother;
            temp.LastDate = model.LastDate;
            temp.DateOfBirth = model.DateOfBirth;
            _app.Patients.Update(temp);
            _app.SaveChanges();
            return Ok(temp);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var temp = _app.Patients.Find(id);
            _app.Patients.Remove(temp);
            _app.SaveChanges();
            return Ok("DELETED");
        }

    }

}
