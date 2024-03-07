using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonalWebsite.Entity.DTO.AboutDTO;
using PersonalWebsite.Entity.DTO.LoginDTO;
using PersonalWebsite.Entity.Poco;
using PersonalWebsite.Entity.Result;
using PersonalWebsite.UI.Controllers;
using RestSharp;
using System;
using System.Security.Policy;

namespace PersonalWebsite.UI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
	[Authorize]
    public class AboutController:BaseController
    {
		private readonly string url = "https://localhost:7018/";
		private readonly HttpClient _httpClient;

		public AboutController(HttpClient httpClient) : base(httpClient)
		{
		}

		[HttpGet("/Admin/About")]
		public async Task<IActionResult> About(AboutDTORequest p)
		{

			UIResponse<AboutDTOResponse> data = await GetAsync<AboutDTOResponse>(url + "About/GetOne/2");
			return View(data);

		}


		[HttpPost("/UpdateAbout")]
		public async Task<JsonResult> UpdateAbout(AboutDTORequest p)
		{
			p.Id = 2;
			if (p.Photo == null)
			{
				UIResponse<AboutDTOResponse> data2 = await GetAsync<AboutDTOResponse>(url + "About/GetOne/2");
				p.Photo = data2.Data.Photo;
				var data = await AddAsync(p, url + "About/AddOrUpdate");

				if (data != null)
				{
					return Json(new { success = true, responseText = " Hakkımda bilgileri güncellenmiştir" });
				}
				return Json(new { success = false, responseText = " Hakkımda bilgileri güncellenemedi" });
			}
			else
			{
				var data = await AddAsync(p, url + "About/AddOrUpdate");
				if (data.Success == true)
				{
					return Json(new { success = true, responseText = " Hakkımda bilgileri güncellenmiştir" });
				}
				return Json(new { success = false, responseText = " Hakkımda bilgileri güncellenemedi" });

			}
		}
	}
}
