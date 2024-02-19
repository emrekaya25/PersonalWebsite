using PersonalWebsite.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Entity.DTO.PortfolioDTO
{
	public class PortfolioDTOResponse
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public IEnumerable<Image> Images { get; set; }
	}
}
