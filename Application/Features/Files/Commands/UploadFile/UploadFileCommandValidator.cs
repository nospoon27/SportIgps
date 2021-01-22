using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Files.Commands.UploadFile
{
    public class UploadFileCommandValidator : AbstractValidator<UploadFileCommand>
    {
        public UploadFileCommandValidator()
        {
            RuleFor(f => f).NotNull().WithMessage("В теле запроса нет файла");
            RuleFor(f => f.File.Length).NotEqual(0).WithMessage("В теле запроса нет файла");
        }
    }
}
