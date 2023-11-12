using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTOs>
	{
		public AppUserRegisterValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş bırakılamaz");
			RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş bırakılamaz");
			RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş bırakılamaz");
			RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı alanı boş bırakılamaz");
			RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş bırakılamaz");
			RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre tekrar alanı boş bırakılamaz");
			RuleFor(x => x.Username).MinimumLength(5).WithMessage("Kullanıcı adınız en az 5 karakter olabilir.");
			RuleFor(x => x.Username).MinimumLength(15).WithMessage("Kullanıcı adınız en fazla 15 karakter olabilir.");
			RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Şifreniz uyuşmuyor.");
		}

	}
}
