using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Business.Abstract;
using PersonalWebsite.Entity.DTO.LoginDTO;
using PersonalWebsite.Entity.DTO.UserDTO;
using PersonalWebsite.Entity.Result;

namespace PersonalWebsite.API.Controllers
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _service;

		public UserController(IUserService service)
		{
			_service = service;
		}

		//[HttpPost]
		//public async Task<IActionResult> GetAll()
		//{
		//	var value = await _service.GetAllAsync();
		//	return Ok(value);
		//}
		[HttpPost]
		public async Task<IActionResult> GetOne()
		{
			int id = 1;
			var value = await _service.GetAsync(id, x => true);
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> AddOrUpdate(UserDTORequest user)
		{
			user.Id = 1;
			ApiResponse<bool> value;
			if (user.Id == 0)
			{
				value = await _service.AddAsync(user);
				return Ok(value);
			}
			value = await _service.UpdateUserAsync(user);
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginDTORequest data)
		{
			var value = await _service.LoginAsync(data);
			return Ok(value);
		}
		//[HttpPost]
		//public async Task<IActionResult> Remove(int id)
		//{

		//	var value = await _service.RemoveAsync(id);
		//	return Ok(value);
		//}
	}
}
