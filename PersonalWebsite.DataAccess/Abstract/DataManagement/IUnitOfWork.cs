using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.DataAccess.Abstract.DataManagement
{
	public interface IUnitOfWork
	{
		public IAboutRepository AboutRepository { get; }
		public IContactRepository ContactRepository { get; }
		public IPortfolioRepository PortfolioRepository { get; }
		public ISkillsRepository SkillsRepository { get; }
		public ISocialRepository SocialRepository { get; }
		public IUserRepository UserRepository { get; }
		Task<int> SaveChangeAsync();
	}
}
