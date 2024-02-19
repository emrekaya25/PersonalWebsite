using PersonalWebsite.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Entity.Poco
{
	public class Image:BaseEntity
	{
		public string Url { get; set; }
		public Portfolio Portfolio { get; set; }
	}
}
