using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonalWebsite.Entity.DTO.AboutDTO;
using PersonalWebsite.Entity.DTO.SocialDTO;
using PersonalWebsite.Entity.Result;
using PersonalWebsite.UI.Models;

namespace PersonalWebsite.UI.ViewComponents
{
	public class IntroViewComponent : ViewComponent
	{
		private readonly HttpClient _httpClient;

		public IntroViewComponent(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			//_httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("Token"));
			var responseMessage = await _httpClient.PostAsync("https://localhost:7018/About/GetOne/2", null);
			var responseMessage2 = await _httpClient.PostAsync("https://localhost:7018/Social/GetAll", null);

			if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UIResponse<AboutDTOResponse>>(jsonData);

				var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
				var value2 = JsonConvert.DeserializeObject<UIResponse<IEnumerable<SocialDTOResponse>>>(jsonData2);
				IntroModel model = new IntroModel();
				model.Social = value2;
				model.About = value;
				//_httpClient.DefaultRequestHeaders.Remove("Authorization");
				return View(model);
			}

			return null;
		}
	}
}
