using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ScheduleEvents.Commands.Create
{
    public class CreateScheduleEventCommandValidation : AbstractValidator<CreateScheduleEventCommand>
    {
        private const int MAX_DURATION_IN_HOUR = 10;
        private const int MIN_DURATION_IN_MINUTE = 15;
        public CreateScheduleEventCommandValidation()
        {
            RuleFor(x => x.Start)
                .NotEmpty()
                .WithMessage("Введите дату начала занятия");

            RuleFor(x => x.End)
                .NotEmpty()
                .WithMessage("Введите дату конца занятия")
                .GreaterThan(x => x.Start)
                .WithMessage("Дата конца занятия должна быть больше начала");

            RuleFor(x => new { x.Start, x.End })
                .Must(x => GetDirrerenceBetweenDatesInHour(x.Start, x.End) < MAX_DURATION_IN_HOUR)
                .WithMessage($"Продолжительность занятия не должно превышать {MAX_DURATION_IN_HOUR} часов");
            RuleFor(x => new { x.Start, x.End })
                .Must(x => GetDifferenceBetweenDatesInMunute(x.Start, x.End) > MIN_DURATION_IN_MINUTE)
                .WithMessage($"Продолжительность занятия не должно быть меньше {MIN_DURATION_IN_MINUTE} минут");
        }

        private int GetDirrerenceBetweenDatesInHour(DateTime start, DateTime end)
        {
            var diffHours = (int)Math.Abs((end - start).TotalHours);
            return diffHours;
        }

        private int GetDifferenceBetweenDatesInMunute(DateTime start, DateTime end)
        {
            var diff = (int)Math.Abs((end - start).TotalMinutes);
            return diff;
        }
    }
}
