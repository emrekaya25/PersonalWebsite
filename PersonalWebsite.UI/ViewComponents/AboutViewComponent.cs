using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonalWebsite.Entity.DTO.AboutDTO;
using PersonalWebsite.Entity.DTO.SkillsDTO;
using PersonalWebsite.Entity.Result;
using PersonalWebsite.UI.Models;

namespace PersonalWebsite.UI.ViewComponents
{
	public class AboutViewComponent : ViewComponent
	{
		private readonly HttpClient _httpClient;

		public AboutViewComponent(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			//_httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("Token"));
			var responseMessage = await _httpClient.PostAsync("https://localhost:7018/About/GetOne/2", null);
			var responseMessage2 = await _httpClient.PostAsync("https://localhost:7018/Skills/GetAll", null);

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UIResponse<AboutDTOResponse>>(jsonData);
				var value2 = JsonConvert.DeserializeObject<UIResponse<IEnumerable<SkillsDTOResponse>>>(jsonData2);
				AboutModel model = new AboutModel()
				{
					About = value,
					Skills = value2
				};
				//_httpClient.DefaultRequestHeaders.Remove("Authorization");
				return View(model);
			}

			return View();
		}
	}
}
