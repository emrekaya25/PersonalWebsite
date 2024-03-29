﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonalWebsite.Entity.DTO.AboutDTO;
using PersonalWebsite.Entity.DTO.SkillsDTO;
using PersonalWebsite.Entity.Result;
using PersonalWebsite.UI.Controllers;
using RestSharp;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PersonalWebsite.UI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class SkillsController : BaseController
    {
        private readonly string url = "https://localhost:7018/";

        public SkillsController(HttpClient httpClient) : base(httpClient)
        {
        }

        [HttpGet("/Admin/Skills")]
        public async Task<IActionResult> Skills()
        {
            UIResponse<List<SkillsDTOResponse>> data = await GetAllAsync<SkillsDTOResponse>(url + "Skills/GetAll");
            return View(data);
        }
        [HttpPost("/CrudSkills")]
        public async Task<IActionResult> CrudSkills(SkillsDTORequest p)
        {
            var data = await AddAsync(p, url + "Skills/AddOrUpdate");

            if (data != null)
            {
                return Json(new { success = true, responseText = " İşlem Başarılı" });
            }
            return Json(new { success = false, responseText = " İşlem Başarısız Oldu!" });
        }
        [HttpPost("/DeleteSkills")]
        public async Task<IActionResult> DeleteSkills(int id)
        {
            var data = await DeleteAsync(url + "Skills/Remove/" + id);
            if (data)
            {
                return Json(new { success = true, responseText = " İşlem Başarılı" });
            }
            return Json(new { success = false, responseText = " İşlem Başarısız Oldu!" });

        }
    }
}
