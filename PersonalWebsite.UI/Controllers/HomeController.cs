using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonalWebsite.Entity.DTO.LoginDTO;
using PersonalWebsite.Entity.Result;
using PersonalWebsite.UI.Models;
using System.Diagnostics;
using System.Security.Claims;
using System.Text;

namespace PersonalWebsite.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;


        public HomeController(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("/Login")]

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("/Log")]
        public async Task<IActionResult> Log(LoginDTORequest p)
        {
            var jsonData = JsonConvert.SerializeObject(p);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync("https://localhost:7018/User/Login", stringContent);
            if (ModelState.IsValid)
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonDataw = await responseMessage.Content.ReadAsStringAsync();
                    var value = JsonConvert.DeserializeObject<UIResponse<LoginDTOResponse>>(jsonDataw);
                    HttpContext.Session.SetString("Token", value.Data.Token);
                    HttpContext.Session.SetString("UserName", value.Data.UserName);
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, value.Data.UserName)); // Kullanýcý adýný JWT'den alabilirsiniz
                    var userIdentity = new ClaimsIdentity(claims, "login");

                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    return Json(new { success = true, redirectTo = Url.Action("Contact", "Contact", new { area = "AdminPanel" }) });

                }
            }
            return Json(new { success = false, responseText = "Kullanýcý Adý yada þifre yanlýþ." });

        }

        public async Task<PartialViewResult> Head()
        {
            return PartialView();
        }
        public async Task<PartialViewResult> Contact()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Message()
        {
            return Ok("OK");
        }
        [HttpGet("/Error404")]
        public async Task<IActionResult> Error404()
        {
            return View();
        }
    }
}
