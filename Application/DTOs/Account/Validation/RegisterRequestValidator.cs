using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Application.DTOs.Account.Validation
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        private string InvalidFormat = "{PropertyName} имеет неверный формат";
        private string Required = "Поле {PropertyName} обязательно к заполнению";
        public RegisterRequestValidator()
        {
            RuleFor(v => v.FirstName)
                .NotNull().WithMessage(Required).WithName("Имя");

            RuleFor(v => v.LastName)
                .NotNull().WithMessage(Required).WithName("Фамилия");

            RuleFor(v => v.PhoneNumber)
                .NotNull().WithMessage(Required).WithName("Номер телефона")
                .MaximumLength(13)
                .MinimumLength(10).WithMessage("{PropertyName} должен состоять от 10 до 13 символов")
                .Matches(@"\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})").WithMessage(InvalidFormat);

            RuleFor(v => v.CountryCode)
                .NotNull().WithMessage(Required)
                .WithName("Код страны")
                .Matches(@"^\+\d{1,3}$").WithMessage(InvalidFormat);

            RuleFor(v => v.Password)
                .NotNull().WithMessage(Required).WithName("Пароль");

            RuleFor(v => v.ConfirmPassword)
                .Equal(p => p.Password)
                .WithMessage("Пароли не совпадают");
        }
    }
}
