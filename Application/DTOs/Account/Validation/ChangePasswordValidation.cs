using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Account.Validation
{
    public class ChangePasswordValidation : AbstractValidator<ChangePasswordRequest>
    {
        public ChangePasswordValidation()
        {
            RuleFor(x => x.CurrentPassword)
                .NotNull().WithMessage("Введите текущий пароль.");

            RuleFor(x => x.NewPassword)
                .NotNull().WithMessage("Введите новый пароль.");
        }
    }
}
