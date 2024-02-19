using PersonalWebsite.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Entity.Poco
{
	public class User:BaseEntity
	{
		public string UserName { get; set; }
		public string Password { get; set; }
	}
}
