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
                .NotNull().WithMessage("Поле 'Имя' обязательно к заполнению");

            RuleFor(v => v.LastName)
                .NotNull().WithMessage("Поле 'Фамилия' обязательно к заполнению");

            RuleFor(v => v.PhoneNumber)
                .NotNull().WithMessage("Поле 'Номер телефона' обязательно к заполнению")
                .MaximumLength(13)
                .MinimumLength(10).WithMessage("Номер телефона должен состоять от 10 до 13 символов");

            RuleFor(v => v.Password)
                .NotNull().WithMessage("Вы забыли указать пароль");

            RuleFor(v => v.ConfirmPassword)
                .Equal(p => p.Password)
                .WithMessage("Пароли не совпадают");
        }
    }
}
