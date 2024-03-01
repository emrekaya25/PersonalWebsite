using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonalWebsite.Entity.DTO.PortfolioDTO;
using PersonalWebsite.Entity.DTO.SkillsDTO;
using PersonalWebsite.Entity.Result;
using RestSharp;

namespace PersonalWebsite.UI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class PortfolioController : Controller
    {
        [HttpGet("/Portfolio")]
        public async Task<IActionResult> Index()
        {
            var url = "https://localhost:7018/Portfolio/GetAll";
            var client = new RestClient(url);
            var request = new RestRequest(url, RestSharp.Method.Post);
            request.AddHeader("Content-Type", "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<UIResponse<List<PortfolioDTOResponse>>>(response.Content);

            return View(responseObject);
        }

		[HttpPost("/AddPortfolio")]
		public async Task<IActionResult> AddPortfolio(PortfolioDTORequest portfolio)
		{
			var url = "https://localhost:7018/Portfolio/AddOrUpdate";
			var client = new RestClient(url);
			var request = new RestRequest(url, RestSharp.Method.Post);
			request.AddHeader("Content-Type", "application/json");
			var body = JsonConvert.SerializeObject(portfolio);
			request.AddBody(body, "application/json");
			RestResponse response = await client.ExecuteAsync(request);
			var responseObject = JsonConvert.DeserializeObject<UIResponse<PortfolioDTOResponse>>(response.Content);

			return View(responseObject.Data);
		}
	}
}
