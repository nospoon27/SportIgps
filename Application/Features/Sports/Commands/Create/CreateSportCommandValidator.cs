using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Sports.Commands.Create
{
    public class CreateSportCommandValidator : AbstractValidator<CreateSportCommand>
    {
        public CreateSportCommandValidator()
        {
            RuleFor(l => l.Name)
                .NotEmpty().WithMessage("{PropertyName} должно быть заполнено")
                .NotNull().WithMessage("{PropertyName} должно быть заполнено");
        }
    }
}
