using AutoMapper;
using PersonalWebsite.Entity.DTO.ContactDTO;
using PersonalWebsite.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Business.Mapper.ContactMapper
{
	public class ContactDTOResponseMapper:Profile
	{
		public ContactDTOResponseMapper()
		{
			CreateMap<Contact,ContactDTOResponse>();
			CreateMap<ContactDTOResponse, Contact>();
		}
	}
}
