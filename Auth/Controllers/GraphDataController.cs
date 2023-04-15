using Auth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphDataController : ControllerBase
    {
        private readonly AppDbContext _app;
        public GraphDataController(AppDbContext app)
        {
            _app = app;
        }

        [HttpGet]
        [Route("summary/med")]
        public async Task<IActionResult> GetMed()
        {
            var diaries = _app.Diaries.ToList();
            GraphModel graph = new GraphModel();
            int error = 0;
            foreach(var diary in diaries)
            {
                var data = diary.Date.Split('-')[1];
                switch (data)
                {
                    case "01":
                    case "1":
                        graph.Jan++;
                        break;
                    case "02":
                    case "2":
                        graph.Feb++;
                        break;
                    case "03":
                    case "3":
                        graph.Mar++;
                        break;
                    case "04":
                    case "4":
                        graph.Apr++;
                        break;
                    case "05":
                    case "5":
                        graph.May++;
                        break;
                    case "06":
                    case "6":
                        graph.Jun++;
                        break;
                    case "07":
                    case "7":
                        graph.Jul++;
                        break;
                    case "08":
                    case "8":
                        graph.Aug++;
                        break;
                    case "09":
                    case "9":
                        graph.Sep++;
                        break;
                    case "10":
                        graph.Oct++;
                        break;
                    case "11":
                        graph.Nov++;
                        break;
                    case "12":
                        graph.Dec++;
                        break;
                    default:
                        error++;
                        break;
                }
            }
            return Ok(graph);
        }

        [HttpGet]
        [Route("summary/reg")]
        public async Task<IActionResult> GetUser()
        {
            var users = _app.Patients.ToList();
            GraphModel graph = new GraphModel();
            int error = 0;
            foreach (var user in users)
            {
                if (user.RegisterDate != null)
                {
                    var data = user.RegisterDate.Split('-')[1];

                    switch (data)
                    {
                        case "01":
                        case "1":
                            graph.Jan++;
                            break;
                        case "02":
                        case "2":
                            graph.Feb++;
                            break;
                        case "03":
                        case "3":
                            graph.Mar++;
                            break;
                        case "04":
                        case "4":
                            graph.Apr++;
                            break;
                        case "05":
                        case "5":
                            graph.May++;
                            break;
                        case "06":
                        case "6":
                            graph.Jun++;
                            break;
                        case "07":
                        case "7":
                            graph.Jul++;
                            break;
                        case "08":
                        case "8":
                            graph.Aug++;
                            break;
                        case "09":
                        case "9":
                            graph.Sep++;
                            break;
                        case "10":
                            graph.Oct++;
                            break;
                        case "11":
                            graph.Nov++;
                            break;
                        case "12":
                            graph.Dec++;
                            break;
                        default:
                            error++;
                            break;
                    }
                }
                
            }
            return Ok(graph);
        }
    }
}
