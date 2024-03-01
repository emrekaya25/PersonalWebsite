using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonalWebsite.Entity.DTO.AboutDTO;
using PersonalWebsite.Entity.DTO.SkillsDTO;
using PersonalWebsite.Entity.Result;
using RestSharp;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PersonalWebsite.UI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class SkillsController : Controller
    {
        [HttpGet("/Skills")]
        public async Task<IActionResult> Index()
        {
			var url = "https://localhost:7018/Skills/GetAll";
			var client = new RestClient(url);
			var request = new RestRequest(url, RestSharp.Method.Post);
			request.AddHeader("Content-Type", "application/json");
			RestResponse response = await client.ExecuteAsync(request);
			var responseObject = JsonConvert.DeserializeObject<UIResponse<List<SkillsDTOResponse>>>(response.Content);

			return View(responseObject);
		}

		[HttpPost("/AddSkill")]
		public async Task<IActionResult> AddSkill(SkillsDTORequest skill)
		{
			var url = "https://localhost:7018/Skills/AddOrUpdate";
			var client = new RestClient(url);
			var request = new RestRequest(url, RestSharp.Method.Post);
			request.AddHeader("Content-Type", "application/json");
			var body = JsonConvert.SerializeObject(skill);
			request.AddBody(body, "application/json");
			RestResponse response = await client.ExecuteAsync(request);
			var responseObject = JsonConvert.DeserializeObject<UIResponse<SkillsDTOResponse>>(response.Content);

			return View(responseObject.Data);
		}
    }
}
