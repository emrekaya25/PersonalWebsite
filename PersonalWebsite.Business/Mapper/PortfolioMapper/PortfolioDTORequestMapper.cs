using AutoMapper;
using PersonalWebsite.Entity.DTO.PortfolioDTO;
using PersonalWebsite.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Business.Mapper.PortfolioMapper
{
	public class PortfolioDTORequestMapper:Profile
	{
		public PortfolioDTORequestMapper()
		{
			CreateMap<Portfolio, PortfolioDTORequest>();
			CreateMap<PortfolioDTORequest, Portfolio>();
		}
	}
}
