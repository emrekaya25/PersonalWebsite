using AutoMapper;
using PersonalWebsite.Business.Abstract;
using PersonalWebsite.DataAccess.Abstract.DataManagement;
using PersonalWebsite.Entity.DTO.PortfolioDTO;
using PersonalWebsite.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Business.Concrete
{
	public class PortfolioManager : GenericManager<PortfolioDTORequest, PortfolioDTOResponse, Portfolio>, IPortfolioService
	{
		public PortfolioManager(IMapper mapper, IUnitOfWork uow) : base(mapper, uow)
		{
		}
	}
}
