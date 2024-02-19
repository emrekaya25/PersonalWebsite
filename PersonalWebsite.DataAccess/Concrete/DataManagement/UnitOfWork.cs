using Microsoft.EntityFrameworkCore;
using PersonalWebsite.DataAccess.Abstract;
using PersonalWebsite.DataAccess.Abstract.DataManagement;
using PersonalWebsite.DataAccess.Concrete.Context;
using PersonalWebsite.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.DataAccess.Concrete.DataManagement
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly PersonalWebSiteContext _context;
		public UnitOfWork(PersonalWebSiteContext context)
		{
			_context = context;

			AboutRepository = new AboutRepository(_context);
			ContactRepository = new ContactRepository(_context);
			PortfolioRepository = new PortfolioRepository(_context);
			SkillsRepository = new SkillsRepository(_context);
			SocialRepository = new SocialRepository(_context);
			UserRepository = new UserRepository(_context);
		}

		public IAboutRepository AboutRepository { get; }

		public IContactRepository ContactRepository { get; }

		public IPortfolioRepository PortfolioRepository { get;}

		public ISkillsRepository SkillsRepository { get; }

		public ISocialRepository SocialRepository { get; }

		public IUserRepository UserRepository { get; }

		public Task<int> SaveChangeAsync()
		{
			return _context.SaveChangesAsync();
		}
	}
}
