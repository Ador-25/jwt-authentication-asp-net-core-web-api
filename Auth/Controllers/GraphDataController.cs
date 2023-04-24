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
            var users = _app.Patients.ToList();
            GraphModel graph = new GraphModel();
            int error = 0;
            List<Data> data = new List<Data>();
            data.Add(
                new Data
                {
                    month = "jan"
                }
                );
            data.Add(
    new Data
    {
        month = "feb"
    }
    );
            data.Add(
    new Data
    {
        month = "mar"
    }
    );
            data.Add(
    new Data
    {
        month = "apr"
    }
    );
            data.Add(
    new Data
    {
        month = "may"
    }
    );
            data.Add(
    new Data
    {
        month = "jun"
    }
    );
            data.Add(
    new Data
    {
        month = "jul"
    }
    );
            data.Add(
    new Data
    {
        month = "aug"
    }
    );
            data.Add(
    new Data
    {
        month = "sept"
    }
    );
            data.Add(
    new Data
    {
        month = "oct"
    }
    );
            data.Add(
    new Data
    {
        month = "nov"
    }
    );
            data.Add(
    new Data
    {
        month = "dec"
    }
    );



            foreach (var diary in diaries)
            {
                try
                {
                    var t = diary.Date.Split('-')[1];
                    switch (t)
                    {
                        case "01":
                        case "1":
                            data[0].mt++;
                            break;
                        case "02":
                        case "2":
                            data[1].mt++;
                            break;
                        case "03":
                        case "3":
                            data[2].mt++;
                            break;
                        case "04":
                        case "4":
                            data[3].mt++;
                            break;
                        case "05":
                        case "5":
                            data[4].mt++;
                            break;
                        case "06":
                        case "6":
                            data[5].mt++;
                            break;
                        case "07":
                        case "7":
                            data[6].mt++;
                            break;
                        case "08":
                        case "8":
                            data[7].mt++;
                            break;
                        case "09":
                        case "9":
                            data[8].mt++;
                            break;
                        case "10":
                            data[9].mt++;
                            break;
                        case "11":
                            data[10].mt++;
                            break;
                        case "12":
                            data[11].mt++;
                            break;
                        default:
                            data[3].mt++ ;
                            break;
                    }
                }
                catch (Exception e)
                {
                    data[3].mt++;
                }
               
            }

            foreach (var user in users)
            {
               

                try
                {
                    var d = user.RegisterDate.Split('-')[1];
                    switch (d)
                    {
                        case "01":
                        case "1":
                            data[0].pt++;
                            break;
                        case "02":
                        case "2":
                            data[1].pt++;
                            break;
                        case "03":
                        case "3":
                            data[2].pt++;
                            break;
                        case "04":
                        case "4":
                            data[3].pt++;
                            break;
                        case "05":
                        case "5":
                            data[4].pt++;
                            break;
                        case "06":
                        case "6":
                            data[5].pt++;
                            break;
                        case "07":
                        case "7":
                            data[6].pt++;
                            break;
                        case "08":
                        case "8":
                            data[7].pt++;
                            break;
                        case "09":
                        case "9":
                            data[8].pt++;
                            break;
                        case "10":
                            data[9].pt++;
                            break;
                        case "11":
                            data[10].pt++;
                            break;
                        case "12":
                            data[11].pt++;
                            break;
                        default:
                            error++;
                            break;
                    }
                }
                catch(Exception ex)
                {

                }
                
            }



            return Ok(data);
        }

        [HttpGet]
        [Route("summary/reg")]
        public async Task<IActionResult> GetUser()
        {
            var users = _app.Patients.ToList();
            var meds =_app.Diaries.ToList();
            GraphModel graph = new GraphModel();
            int error = 0;
           

            List<Data> data = new List<Data>();
            data.Add(
                new Data
                {
                    month="jan"
                }
                );
            data.Add(
    new Data
    {
        month = "feb"
    }
    );
            data.Add(
    new Data
    {
        month = "mar"
    }
    );
            data.Add(
    new Data
    {
        month = "apr"
    }
    );
            data.Add(
    new Data
    {
        month = "may"
    }
    );
            data.Add(
    new Data
    {
        month = "jun"
    }
    );
            data.Add(
    new Data
    {
        month = "jul"
    }
    );
            data.Add(
    new Data
    {
        month = "aug"
    }
    );
            data.Add(
    new Data
    {
        month = "sept"
    }
    );
            data.Add(
    new Data
    {
        month = "oct"
    }
    );
            data.Add(
    new Data
    {
        month = "nov"
    }
    );
            data.Add(
    new Data
    {
        month = "dec"
    }
    );

            foreach (var user in users)
            {
                if (user.RegisterDate != null)
                {
                    try
                    {
                        var d = user.RegisterDate.Split('-')[1];
                        switch (d)
                        {
                            case "01":
                            case "1":
                                data[0].pt++;
                                break;
                            case "02":
                            case "2":
                                data[1].pt++;
                                break;
                            case "03":
                            case "3":
                                data[2].pt++;
                                break;
                            case "04":
                            case "4":
                                data[3].pt++;
                                break;
                            case "05":
                            case "5":
                                data[4].pt++;
                                break;
                            case "06":
                            case "6":
                                data[5].pt++;
                                break;
                            case "07":
                            case "7":
                                data[6].pt++;
                                break;
                            case "08":
                            case "8":
                                data[7].pt++;
                                break;
                            case "09":
                            case "9":
                                data[8].pt++;
                                break;
                            case "10":
                                data[9].pt++;
                                break;
                            case "11":
                                data[10].pt++;
                                break;
                            case "12":
                                data[11].pt++;
                                break;
                            default:
                                error++;
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        data[3].pt++;
                    }
                    
                }

            }
            return Ok(data);
        }
    }
}
