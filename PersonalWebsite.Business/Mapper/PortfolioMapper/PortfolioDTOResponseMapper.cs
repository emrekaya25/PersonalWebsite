using AutoMapper;
using PersonalWebsite.Entity.DTO.ImageDTO;
using PersonalWebsite.Entity.DTO.PortfolioDTO;
using PersonalWebsite.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Business.Mapper.PortfolioMapper
{
	public class PortfolioDTOResponseMapper:Profile
	{
		public PortfolioDTOResponseMapper() 
		{
			CreateMap<Portfolio,PortfolioDTOResponse>();
			CreateMap<PortfolioDTOResponse, Portfolio>();

			CreateMap<ImageDTOResponse, Image>();
			CreateMap<Image, ImageDTOResponse>();
		}
	}
}
