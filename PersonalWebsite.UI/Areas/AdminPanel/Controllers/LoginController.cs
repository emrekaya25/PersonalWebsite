using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonalWebsite.Entity.DTO.LoginDTO;
using PersonalWebsite.Entity.Result;
using RestSharp;

namespace PersonalWebsite.UI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class LoginController : Controller
    {
        private readonly HttpClient _httpClient;

        public LoginController(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }

        [HttpGet("/Login")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/GirisYap")]
        public async Task<IActionResult> AdminLogin(LoginDTORequest loginDTORequest)
        {
            var url = "https://localhost:7018/User/Login";
            var client = new RestClient(url);
            var request = new RestRequest(url, RestSharp.Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = JsonConvert.SerializeObject(loginDTORequest);
            request.AddBody(body, "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResponse<LoginDTOResponse>>(response.Content);

            if (responseObject.Data == null)
            {
                return RedirectToAction("Index","Login");
            }
            return RedirectToAction("Index","AdminHome");
        }
    }
}
