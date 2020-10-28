using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Application.DTOs.Account.Validation
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        private readonly string InvalidFormat = "{PropertyName} имеет неверный формат";
        private readonly string Required = "Поле {PropertyName} обязательно к заполнению";
        public RegisterRequestValidator()
        {
            RuleFor(v => v.FirstName)
                .NotNull().WithMessage(Required).WithName("Имя");

            RuleFor(v => v.LastName)
                .NotNull().WithMessage(Required).WithName("Фамилия");

            RuleFor(v => v.PhoneNumber)
                .NotNull().WithMessage(Required).WithName("Номер телефона")
                .Matches(@"\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})").WithMessage(InvalidFormat);

            //RuleFor(v => v.CountryCode)
            //    .NotEqual(0).WithMessage(Required)
            //    .WithName("Код страны")
            //    .Matches(@"^\+\d{1,3}$").WithMessage(InvalidFormat);

            RuleFor(v => v.CountryCodeId)
                .NotEqual(0).WithMessage(Required)
                .WithName("Код страны");

            RuleFor(v => v.Password)
                .NotEmpty().WithMessage(Required).WithName("Пароль");

            //RuleFor(v => v.ConfirmPassword)
            //    .Equal(p => p.Password)
            //    .WithMessage("Пароли не совпадают");

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.Password != x.ConfirmPassword)
                {
                    context.AddFailure(nameof(x.ConfirmPassword), "Пароли не совпадают");
                }
            });
        }
    }
}
