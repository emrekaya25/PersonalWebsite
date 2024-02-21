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
	public class UserDTORequestMapper:Profile
	{
		public UserDTORequestMapper()
		{
			CreateMap<User, UserDTORequest>();
			CreateMap<UserDTORequest, User>();


			CreateMap<LoginDTORequest, User>();
			CreateMap<User, LoginDTORequest>();
		}
	}
}
