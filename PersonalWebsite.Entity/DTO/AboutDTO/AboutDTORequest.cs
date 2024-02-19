using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Entity.DTO.AboutDTO
{
	public class AboutDTORequest
	{
		public string PhotoUrl { get; set; }
		public string Description { get; set; }
		public string Resume { get; set; }
		public string Name { get; set; }
		public DateOnly BirthDate { get; set; }
		public string Job { get; set; }
		public string Mail { get; set; }
		public string SkillText { get; set; }
	}
}
