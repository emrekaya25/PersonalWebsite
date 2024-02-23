using PersonalWebsite.Entity.DTO.AboutDTO;
using PersonalWebsite.Entity.DTO.SkillsDTO;
using PersonalWebsite.Entity.Result;

namespace PersonalWebsite.UI.Models
{
	public class AboutModel
	{
		public UIResponse<AboutDTOResponse> About { get; set; }
		public UIResponse<IEnumerable<SkillsDTOResponse>> Skills { get; set; }
	}
}
