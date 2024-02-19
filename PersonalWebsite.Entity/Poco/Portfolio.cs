using PersonalWebsite.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Entity.Poco
{
	public class Portfolio:BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }

		public IEnumerable<Image> Images { get; set; }
	}
}
