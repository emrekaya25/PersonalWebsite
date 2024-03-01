using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonalWebsite.Entity.DTO.PortfolioDTO;
using PersonalWebsite.Entity.DTO.SocialDTO;
using PersonalWebsite.Entity.Result;
using RestSharp;

namespace PersonalWebsite.UI.Areas.AdminPanel.Controllers
{
	[Area("AdminPanel")]
	public class SocialController : Controller
	{
		[HttpGet("/Social")]
		public async Task<IActionResult> Index()
		{
			var url = "https://localhost:7018/Social/GetAll";
			var client = new RestClient(url);
			var request = new RestRequest(url, RestSharp.Method.Post);
			request.AddHeader("Content-Type", "application/json");
			RestResponse response = await client.ExecuteAsync(request);
			var responseObject = JsonConvert.DeserializeObject<UIResponse<List<SocialDTOResponse>>>(response.Content);

			return View(responseObject);
		}
	}
}
