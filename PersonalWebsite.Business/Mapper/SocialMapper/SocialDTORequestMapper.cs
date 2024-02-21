using AutoMapper;
using PersonalWebsite.Entity.DTO.SocialDTO;
using PersonalWebsite.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Business.Mapper.SocialMapper
{
	public class SocialDTORequestMapper:Profile
	{
		public SocialDTORequestMapper()
		{
			CreateMap<Social, SocialDTORequest>();
			CreateMap<SocialDTORequest, Social>();
		}
	}
}
