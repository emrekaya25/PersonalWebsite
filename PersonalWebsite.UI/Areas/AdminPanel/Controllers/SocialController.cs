using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonalWebsite.Entity.DTO.PortfolioDTO;
using PersonalWebsite.Entity.DTO.SocialDTO;
using PersonalWebsite.Entity.Result;
using PersonalWebsite.UI.Controllers;
using RestSharp;

namespace PersonalWebsite.UI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class SocialController : BaseController
	{
        private readonly string url = "https://localhost:7018/";
        private readonly IWebHostEnvironment _hostingEnvironment;

        public SocialController(HttpClient httpClient, IWebHostEnvironment hostingEnvironment) : base(httpClient)
        {
            _hostingEnvironment = hostingEnvironment;

        }

        [HttpGet("/Admin/Social")]
        public async Task<IActionResult> Social()
        {
            UIResponse<List<SocialDTOResponse>> data = await GetAllAsync<SocialDTOResponse>(url + "Social/GetAll");
            return View(data);
        }
        [HttpPost("/CrudSocial")]
        public async Task<IActionResult> CrudSocial(SocialDTORequest p, IFormFile ImageFile)
        {
            if (ImageFile != null)
            {
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
                var imagePath = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "images", uniqueFileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }
                p.Image = uniqueFileName;
                var data = await AddAsync(p, url + "Social/AddOrUpdate");

                if (data != null)
                {
                    return Json(new { success = true, responseText = " İşlem Başarılı" });
                }
                return Json(new { success = false, responseText = " İşlem Başarısız Oldu!" });
            }
            else
            {
                var data = await AddAsync(p, url + "Social/AddOrUpdate");
                if (data.Success == true)
                {
                    return Json(new { success = true, responseText = " İşlem Başarılı" });
                }
                return Json(new { success = false, responseText = " İşlem Başarısız Oldu!" });

            }

        }
        [HttpPost("/DeleteSocial")]
        public async Task<IActionResult> DeleteSocial(int id)
        {
            var data = await DeleteAsync(url + "Social/Remove/" + id);
            if (data)
            {
                return Json(new { success = true, responseText = " İşlem Başarılı" });
            }
            return Json(new { success = false, responseText = " İşlem Başarısız Oldu!" });

        }
    }
}
