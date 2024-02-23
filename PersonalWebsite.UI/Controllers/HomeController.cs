using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.UI.Models;
using System.Diagnostics;

namespace PersonalWebsite.UI.Controllers
{
	public class HomeController : BaseController
	{
		public HomeController(HttpClient httpClient) : base(httpClient)
		{
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<PartialViewResult> Head()
		{
			return PartialView();
		}
		public async Task<PartialViewResult> Contact()
		{
			return PartialView();
		}
	}
}
