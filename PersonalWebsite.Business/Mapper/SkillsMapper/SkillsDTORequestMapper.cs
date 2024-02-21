using AutoMapper;
using PersonalWebsite.Entity.DTO.SkillsDTO;
using PersonalWebsite.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Business.Mapper.SkillsMapper
{
	public class SkillsDTORequestMapper:Profile
	{
		public SkillsDTORequestMapper()
		{
			CreateMap<Skills, SkillsDTORequest>();
			CreateMap<SkillsDTORequest, Skills>();
		}
	}
}
