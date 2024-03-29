﻿using FluentValidation;
using PersonalWebsite.Entity.DTO.SocialDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Business.ValidationRules
{
	public class SocialValidator:AbstractValidator<SocialDTORequest>
	{
        public SocialValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Sosyal medya ismi boş olamaz.");
            RuleFor(x=>x.Url).NotEmpty().WithMessage("Sosyal medya ikonu boş olamaz.");
            RuleFor(x=>x.Image).NotEmpty().WithMessage("Sosyal medya fotoğrafı boş olamaz.");
        }
    }
}
