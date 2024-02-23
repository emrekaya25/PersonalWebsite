using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonalWebsite.Entity.DTO.PortfolioDTO;
using PersonalWebsite.Entity.Result;

namespace PersonalWebsite.UI.ViewComponents
{
	public class PortfolioViewComponent : ViewComponent
	{
		private readonly HttpClient _httpClient;

		public PortfolioViewComponent(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			//_httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("Token"));
			var responseMessage = await _httpClient.PostAsync("https://localhost:7018/Portfolio/GetAll", null);

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UIResponse<IEnumerable<PortfolioDTOResponse>>>(jsonData);
				//_httpClient.DefaultRequestHeaders.Remove("Authorization");
				return View(value);
			}

			return View();
		}
	}
}
