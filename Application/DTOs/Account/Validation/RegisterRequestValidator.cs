using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Application.DTOs.Account.Validation
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(v => v.FirstName)
                .NotNull().WithMessage("Поле {PropertyName} обязательно к заполнению").WithName("Имя");

            RuleFor(v => v.LastName)
                .NotNull().WithMessage("Поле {PropertyName} обязательно к заполнению").WithName("Фамилия");

            RuleFor(v => v.PhoneNumber)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Поле {PropertyName} обязательно к заполнению").WithName("Номер телефона")
                .MaximumLength(13)
                .MinimumLength(10).WithMessage("Номер телефона должен состоять от 10 до 13 символов");

            RuleFor(v => v.Password)
                .NotNull().WithMessage("Вы забыли указать пароль").WithName("Пароль");

            RuleFor(v => v.ConfirmPassword)
                .Equal(p => p.Password)
                .WithMessage("Пароли не совпадают");
        }
    }
}
