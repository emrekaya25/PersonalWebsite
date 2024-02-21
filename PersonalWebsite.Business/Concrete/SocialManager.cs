using AutoMapper;
using PersonalWebsite.Business.Abstract;
using PersonalWebsite.DataAccess.Abstract.DataManagement;
using PersonalWebsite.Entity.DTO.SocialDTO;
using PersonalWebsite.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Business.Concrete
{
	public class SocialManager : GenericManager<SocialDTORequest, SocialDTOResponse, Social>, ISocialService
	{
		public SocialManager(IMapper mapper, IUnitOfWork uow) : base(mapper, uow)
		{
		}
	}
}
