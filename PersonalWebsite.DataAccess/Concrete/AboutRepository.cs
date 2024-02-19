using Microsoft.EntityFrameworkCore;
using PersonalWebsite.DataAccess.Abstract;
using PersonalWebsite.DataAccess.Concrete.DataManagement;
using PersonalWebsite.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.DataAccess.Concrete
{
	public class AboutRepository : Repository<About>, IAboutRepository
	{
		public AboutRepository(DbContext context) : base(context)
		{
		}
	}
}
