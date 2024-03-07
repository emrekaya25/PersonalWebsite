using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Entity.DTO.ContactDTO;
using PersonalWebsite.Entity.Result;
using PersonalWebsite.UI.Controllers;

namespace PersonalWebsite.UI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class ContactController : BaseController
    {
        private readonly string url = "https://localhost:7018/";
        public ContactController(HttpClient httpClient) : base(httpClient)
        {

        }
        [HttpGet("/Admin/Contact")]
        public async Task<IActionResult> Contact()
        {
            UIResponse<List<ContactDTOResponse>> data = await GetAllAsync<ContactDTOResponse>(url + "Contact/GetAll");
            return View(data);
        }
        [HttpPost("/CrudContact")]
        public async Task<IActionResult> CrudContact(ContactDTORequest p)
        {
            var data = await AddAsync(p, url + "Contact/AddOrUpdate");

            if (data != null)
            {
                return Json(new { success = true, responseText = " İşlem Başarılı" });
            }
            return Json(new { success = false, responseText = " İşlem Başarısız Oldu!" });
        }

        [HttpPost("/DeleteContact")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var data = await DeleteAsync(url + "Contact/Remove/" + id);
            if (data)
            {
                return Json(new { success = true, responseText = " İşlem Başarılı" });
            }
            return Json(new { success = false, responseText = " İşlem Başarısız Oldu!" });

        }
    }
}
