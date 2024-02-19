using Microsoft.AspNetCore.Mvc;

namespace PersonalWebsiteUI.Areas.SiteUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> Intro()
        {
            return PartialView();
        }

        public async Task<PartialViewResult> About()
        {
            return PartialView();
        }

        public async Task<PartialViewResult> Portfolio()
        {
            return PartialView();
        }

        public async Task<PartialViewResult> Services()
        {
            return PartialView();
        }

        public async Task<PartialViewResult> Contact()
        {
            return PartialView();
        }

        public async Task<PartialViewResult> Footer()
        {
            return PartialView();
        }
    }
}
