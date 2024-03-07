using PersonalWebsite.Entity.DTO.LoginDTO;
using PersonalWebsite.Entity.DTO.UserDTO;
using PersonalWebsite.Entity.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Business.Abstract
{
	public interface IUserService:IGenericService<UserDTORequest,UserDTOResponse>
	{
		Task<ApiResponse<UserDTOResponse>> UpdateUserAsync(UserDTORequest Entity);
		Task<ApiResponse<LoginDTOResponse>> LoginAsync(LoginDTORequest Entity);
	}
}
