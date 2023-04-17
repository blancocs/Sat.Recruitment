using System.Collections.Generic;
using System;
using FluentValidation.Results;

namespace Sat.Recruitment.Api.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base("The following validation errors have occurred")
        {
            Errors = new List<string>();

        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }

        public List<string> Errors { get; }

    }
}
