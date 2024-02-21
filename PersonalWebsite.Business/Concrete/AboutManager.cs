using AutoMapper;
using PersonalWebsite.Business.Abstract;
using PersonalWebsite.DataAccess.Abstract.DataManagement;
using PersonalWebsite.Entity.Base;
using PersonalWebsite.Entity.DTO;
using PersonalWebsite.Entity.DTO.AboutDTO;
using PersonalWebsite.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Business.Concrete
{
	public class AboutManager : GenericManager<AboutDTORequest, AboutDTOResponse, About>, IAboutService
	{
		public AboutManager(IMapper mapper, IUnitOfWork uow) : base(mapper, uow)
		{
		}
	}
}
