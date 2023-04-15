using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslatorController : ControllerBase
    {


        private const string ApiKey = "your-api-key-here";
        private const string ApiUrl = "https://translate.yandex.net/api/v1.5/tr.json/translate";

        public static async Task<string> Translate(string text)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"{ApiUrl}?key={ApiKey}&text={text}&lang=el-en");
                response.EnsureSuccessStatusCode();

                var responseJson = await response.Content.ReadAsStringAsync();
                var translation = Newtonsoft.Json.JsonConvert.DeserializeObject<TranslationResponse>(responseJson);

                return translation.text[0];
            }
        }
    

    public class TranslationResponse
    {
        public int code { get; set; }
        public string lang { get; set; }
        public string[] text { get; set; }
    }

}
}
