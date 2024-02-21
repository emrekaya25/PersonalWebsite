using PersonalWebsite.Entity.DTO.AboutDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Business.Abstract
{
	public interface IAboutService:IGenericService<AboutDTORequest,AboutDTOResponse>
	{
	}
}
