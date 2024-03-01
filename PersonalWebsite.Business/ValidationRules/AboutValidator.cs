using FluentValidation;
using PersonalWebsite.Entity.DTO.AboutDTO;
using PersonalWebsite.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Business.ValidationRules
{
	public class AboutValidator:AbstractValidator<AboutDTORequest>
	{
		public AboutValidator() 
		{
			RuleFor(x => x.NameSurname).MinimumLength(2).WithMessage("Kullanıcı adı 2 karakterden büyük olmalıdır.");
			RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Kullanıcı adı boş olamaz.");
			RuleFor(x => x.Resume).NotEmpty().WithMessage("Özgeçmiş boş olamaz.");
			RuleFor(x => x.Mail).Matches("[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$").WithMessage("E-Posta Formatı Doğru Değil!!");
			RuleFor(x => x.Photo).NotEmpty().WithMessage("Resim boş olamaz.");
			RuleFor(x => x.BirthDate).NotEmpty().WithMessage("Doğum tarihi boş olamaz.");
		}
	}
}
