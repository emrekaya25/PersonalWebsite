using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Business.Abstract;
using PersonalWebsite.Entity.DTO.ContactDTO;
using PersonalWebsite.Entity.Result;

namespace PersonalWebsite.API.Controllers
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private readonly IContactService _service;

		public ContactController(IContactService service)
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
			var deneme = new ContactDTOResponse();
			deneme.Id = id;
			var value = await _service.GetAsync(id, x => true);
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> AddOrUpdate(ContactDTORequest contact)
		{
			ApiResponse<bool> value;
			if (contact.Id == 0)
			{
				value = await _service.AddAsync(contact);
				return Ok(value);
			}

			value = await _service.UpdateAsync(contact);
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
