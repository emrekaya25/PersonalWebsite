using PersonalWebsite.DataAccess.Abstract.DataManagement;
using PersonalWebsite.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.DataAccess.Abstract
{
	public interface IUserRepository:IRepository<User>
	{
	}
}
