using PersonalWebsite.Entity.DTO.AboutDTO;
using PersonalWebsite.Entity.DTO.SocialDTO;
using PersonalWebsite.Entity.Result;

namespace PersonalWebsite.UI.Models
{
	public class IntroModel
	{
		public UIResponse<AboutDTOResponse> About { get; set; }
		public UIResponse<IEnumerable<SocialDTOResponse>> Social { get; set; }
	}
}
