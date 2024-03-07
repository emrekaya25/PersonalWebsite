using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonalWebsite.Entity.DTO.AboutDTO;
using PersonalWebsite.Entity.DTO.LoginDTO;
using PersonalWebsite.Entity.Poco;
using PersonalWebsite.Entity.Result;
using PersonalWebsite.UI.Controllers;
using RestSharp;

namespace PersonalWebsite.UI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class AdminHomeController : BaseController
    {
        private readonly string url = "https://localhost:7018/";

        public AdminHomeController(HttpClient httpClient) : base(httpClient)
        {

        }
        [HttpGet("AdminHome")]
        public IActionResult Index()
        {
            return View();
        }

    }
}
