using AutoMapper;
using PersonalWebsite.Entity.DTO.LoginDTO;
using PersonalWebsite.Entity.DTO.UserDTO;
using PersonalWebsite.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Business.Mapper.UserMapper
{
	public class UserDTOResponseMapper:Profile
	{
		public UserDTOResponseMapper() 
		{
			CreateMap<User,UserDTOResponse>();
			CreateMap<UserDTOResponse, User>();

			CreateMap<LoginDTOResponse, User>();
			CreateMap<User, LoginDTOResponse>();
		}
	}
}
