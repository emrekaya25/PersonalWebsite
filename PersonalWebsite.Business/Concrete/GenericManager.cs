using AutoMapper;
using PersonalWebsite.Business.Abstract;
using PersonalWebsite.Business.Aspects;
using PersonalWebsite.Business.ValidationRules;
using PersonalWebsite.DataAccess.Abstract.DataManagement;
using PersonalWebsite.Entity.Base;
using PersonalWebsite.Entity.Result;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Business.Concrete
{
	public class GenericManager<TRequest, TResponse, TEntity> : IGenericService<TRequest, TResponse> where TResponse : class where TRequest : class where TEntity : BaseEntity
	{
		private readonly IUnitOfWork _uow;
		private readonly IMapper _mapper;

		public GenericManager(IMapper mapper, IUnitOfWork uow)
		{
			_mapper = mapper;
			_uow = uow;
		}
		
		public async Task<ApiResponse<bool>> AddAsync(TRequest p)
		{
			var result = new ApiResponse<bool>();
			var data = _mapper.Map<TEntity>(p);
			await _uow.GetRepository<TEntity>().AddAsync(data);
			result.Data = await _uow.SaveChangesAsync();
			return result;
		}

		public async Task<ApiResponse<IEnumerable<TResponse>>> GetAllAsync(Expression<Func<TResponse, bool>> Filter = null, params string[] IncludeProperties)
		{
			var result = new ApiResponse<IEnumerable<TResponse>>();
			var data = await _uow.GetRepository<TEntity>().GetAllAsync();
			var mappdata = _mapper.Map<IEnumerable<TResponse>>(data);
			result.Data = mappdata;
			return result;
		}

		public async Task<ApiResponse<TResponse>> GetAsync(int id, Expression<Func<TResponse, bool>> Filter, params string[] IncludeProperties)
		{
			var result = new ApiResponse<TResponse>();
			var data = await _uow.GetRepository<TEntity>().GetAsync(x => x.Id == id);
			var mappdata = _mapper.Map<TResponse>(data);
			result.Data = mappdata;
			return result;
		}

		public async Task<ApiResponse<bool>> RemoveAsync(int p)
		{
			var result = new ApiResponse<bool>();
			await _uow.GetRepository<TEntity>().RemoveAsync(p);
			result.Data = await _uow.SaveChangesAsync();
			return result;
		}

		public async Task<ApiResponse<bool>> UpdateAsync(TRequest p)
		{
			var result = new ApiResponse<bool>();
			var data = _mapper.Map<TEntity>(p);
			await _uow.GetRepository<TEntity>().UpdateAsync(data);
			result.Data = await _uow.SaveChangesAsync();
			return result;
		}

	}
}
