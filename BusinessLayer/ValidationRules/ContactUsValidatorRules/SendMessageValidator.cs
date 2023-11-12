using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.ContactUsValidatorRules
{
    public class SendMessageValidator : AbstractValidator<SendMessageDto>
    {
        public SendMessageValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Mesaj Alanı Boş Geçilemez!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Alanı Boş Geçilemez!");
            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Mesaj Alanı Boş Geçilemez!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Alanı Boş Geçilemez!");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Konu en az 5 karakter olabilir.");
            RuleFor(x => x.Subject).MaximumLength(25).WithMessage("Konu en fazla 25 karakter olabilir.");
        }
    }
}
