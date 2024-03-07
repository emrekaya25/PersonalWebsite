using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Business.Abstract;
using PersonalWebsite.Entity.DTO.PortfolioDTO;
using PersonalWebsite.Entity.Result;

namespace PersonalWebsite.API.Controllers
{
	[Route("[controller]/[action]")]
	[ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _service;

        public PortfolioController(IPortfolioService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> GetAll()
        {
            var value = await _service.GetAllAsync(x => x.Name != null, "Images");
            return Ok(value);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var deneme = new PortfolioDTOResponse();
            deneme.Id = id;
            var value = await _service.GetAsync(id, x => true, "Images");
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrUpdate(PortfolioDTORequest about)
        {
            ApiResponse<PortfolioDTOResponse> value;
            if (about.Id == 0)
            {
                value = await _service.AddAsync(about);
                return Ok(value);
            }
            value = await _service.UpdateAsync(about);
            return Ok(value);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Remove(int id)
        {

            var value = await _service.RemoveAsync(id);
            return Ok(value);
        }
    }
}
