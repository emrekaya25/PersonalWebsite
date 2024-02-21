using AutoMapper;
using PersonalWebsite.Entity.DTO.AboutDTO;
using PersonalWebsite.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Business.Mapper.AboutMapper
{
	public class AboutDTOResponseMapper:Profile
	{
		public AboutDTOResponseMapper()
		{
			CreateMap<About, AboutDTOResponse>();
			CreateMap<AboutDTOResponse, About>();
		}
	}
}
