using FluentValidation.Results;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Exceptions
{
    public class CustomValidationException : Exception
    {
        public CustomValidationException()
            : base("Произошла одна или несколько ошибок при проверке запроса.")
        {
            Failures = new Dictionary<string, string[]>();
        }

        public CustomValidationException(IList<ValidationFailure> failures)
            : this()
        {
            var propertyNames = failures
                .Select(e => e.PropertyName)
                .Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = failures
                    .Where(e => e.PropertyName == propertyName)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                Failures.Add(propertyName.Camelize(), propertyFailures);
            }
        }

        public IDictionary<string, string[]> Failures { get; }
    }
}
