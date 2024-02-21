using PersonalWebsite.Entity.Base;
using PersonalWebsite.Entity.DTO;
using PersonalWebsite.Entity.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Business.Abstract
{
	public interface IGenericService<TRequest, TResponse>
	{
		Task<ApiResponse<TResponse>> GetAsync(int id, Expression<Func<TResponse, bool>> Filter, params string[] IncludeProperties);
		Task<ApiResponse<IEnumerable<TResponse>>> GetAllAsync(Expression<Func<TResponse, bool>> Filter = null, params string[] IncludeProperties);

		Task<ApiResponse<bool>> AddAsync(TRequest Entity);

		Task<ApiResponse<bool>> UpdateAsync(TRequest Entity);

		Task<ApiResponse<bool>> RemoveAsync(int id);

	}
}
