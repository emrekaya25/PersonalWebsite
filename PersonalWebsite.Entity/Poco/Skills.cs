using PersonalWebsite.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Entity.Poco
{
	public class Skills:BaseEntity
	{
		public string Name { get; set; }
		public int Percent { get; set; }
	}
}
