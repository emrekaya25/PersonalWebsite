using FluentValidation;
using PersonalWebsite.Entity.DTO.ImageDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Business.ValidationRules
{
	public class ImageValidator:AbstractValidator<ImageDTORequest>
	{
        public ImageValidator()
        {
            RuleFor(x => x.Url).NotEmpty().WithMessage("Fotoğraf boş olamaz.");
        }
    }
}
