using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Account.Validation
{
    public class AuthenticationRequestValidator : AbstractValidator<AuthenticationRequest>
    {
        public AuthenticationRequestValidator()
        {
            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("Забыли указать пароль");

            RuleFor(v => v.PhoneNumber)
                .NotNull().WithMessage("Поле 'Номер телефона' обязательно к заполнению")
                .MaximumLength(13)
                .MinimumLength(10).WithMessage("Номер телефона должен состоять от 10 до 13 символов");
        }
    }
}
