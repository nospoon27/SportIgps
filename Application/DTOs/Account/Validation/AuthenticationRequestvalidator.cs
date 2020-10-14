using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Account.Validation
{
    public class AuthenticationRequestValidator : AbstractValidator<AuthenticationRequest>
    {
        private readonly string Required = "Поле {PropertyName} обязательно к заполнению";

        public AuthenticationRequestValidator()
        {
            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage(Required);

            RuleFor(v => v.PhoneNumber)
                .NotNull().WithMessage(Required)
                .MaximumLength(13)
                .MinimumLength(10).WithMessage("Номер телефона должен состоять от {MinLength} до {MaxLength} символов");

            RuleFor(v => v.CountryCodeId)
                .NotEqual(0).WithMessage(Required)
                .WithName("Код страны");
        }
    }
}
