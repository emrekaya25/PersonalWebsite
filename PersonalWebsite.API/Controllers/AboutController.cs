using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Business.Abstract;
using PersonalWebsite.Business.Aspects;
using PersonalWebsite.Business.ValidationRules;
using PersonalWebsite.Entity.DTO.AboutDTO;
using PersonalWebsite.Entity.Result;

namespace PersonalWebsite.API.Controllers
{
	[Route("[controller]/[action]")]
	[ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _service;

        public AboutController(IAboutService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> GetAll()
        {
            var value = await _service.GetAllAsync();
            return Ok(value);
        }
        //[HttpPost("{id}")]
        //public async Task<IActionResult> GetOne(int id)
        //{
        //	var deneme=new AboutGetDTO();
        //	deneme.Id = id;
        //	var value = await _service.GetAsync(id,x=>true);
        //	return Ok(value);
        //}

        [HttpPost("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var deneme = new AboutDTOResponse();
            deneme.Id = id;
            var value = await _service.GetAsync(id, x => true);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrUpdate(AboutDTORequest about)
        {
            ApiResponse<AboutDTOResponse> value;
            if (about.Id == 0)
            {
                value = await _service.AddAsync(about);
                return Ok(value);
            }
            value = await _service.UpdateAsync(about);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {

            var value = await _service.RemoveAsync(id);
            return Ok(value);
        }
    }
}
