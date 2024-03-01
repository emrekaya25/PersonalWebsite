using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Business.Abstract;
using PersonalWebsite.Entity.DTO.SkillsDTO;
using PersonalWebsite.Entity.Result;

namespace PersonalWebsite.API.Controllers
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class SkillsController : ControllerBase
	{
		private readonly ISkillsService _service;

		public SkillsController(ISkillsService service)
		{
			_service = service;
		}

		[HttpPost]
		public async Task<IActionResult> GetAll()
		{
			var value = await _service.GetAllAsync();
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> GetOne(int id)
		{
			var deneme = new SkillsDTOResponse();
			deneme.Id = id;
			var value = await _service.GetAsync(id, x => true);
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> AddOrUpdate(SkillsDTORequest skill)
		{
			ApiResponse<bool> value;
			if (skill.Id == 0)
			{
				value = await _service.AddAsync(skill);
				return Ok(value);
			}
			value = await _service.UpdateAsync(skill);
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
