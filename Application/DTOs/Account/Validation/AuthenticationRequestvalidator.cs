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
                .WithMessage(Required)
                .Length(6);

            RuleFor(v => v.PhoneNumber)
                .NotNull().WithMessage(Required);

            RuleFor(v => v.CountryCodeId)
                .NotEqual(0).WithMessage(Required)
                .WithName("Код страны");
        }
    }
}
