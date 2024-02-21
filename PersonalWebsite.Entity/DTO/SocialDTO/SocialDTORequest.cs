using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Entity.DTO.SocialDTO
{
	public class SocialDTORequest
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }
		public string Image { get; set; }
	}
}
