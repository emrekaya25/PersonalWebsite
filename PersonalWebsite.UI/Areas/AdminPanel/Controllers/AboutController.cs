using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonalWebsite.Entity.DTO.AboutDTO;
using PersonalWebsite.Entity.DTO.LoginDTO;
using PersonalWebsite.Entity.Poco;
using PersonalWebsite.Entity.Result;
using RestSharp;
using System;
using System.Security.Policy;

namespace PersonalWebsite.UI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class AboutController:Controller
    {
        private readonly HttpClient _httpClient;

        public AboutController(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }

        [HttpGet("/About")]
        public async Task<IActionResult> Index()
        {
            var url = "https://localhost:7018/About/GetOne/2";
            var client = new RestClient(url);
            var request = new RestRequest(url, RestSharp.Method.Post);
            request.AddHeader("Content-Type", "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<UIResponse<AboutDTOResponse>>(response.Content);

            return View(responseObject);
        }

        [HttpPost("/UpdateAbout")]
        public async Task<IActionResult> UpdateAbout(AboutDTORequest data)
        {
            var url = "https://localhost:7018/About/AddOrUpdate";
            var client = new RestClient(url);
            var request = new RestRequest(url, RestSharp.Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = JsonConvert.SerializeObject(data);
            request.AddBody(body, "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<UIResponse<AboutDTOResponse>>(response.Content);

            return View(responseObject.Data);
        }
    }
}
