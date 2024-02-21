using FluentValidation;
using PersonalWebsite.Entity.DTO.PortfolioDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Business.ValidationRules
{
	public class PortfolioValidator:AbstractValidator<PortfolioDTORequest>
	{
        public PortfolioValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş olamaz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş olamaz.");
        }
    }
}
