using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Positano.Application
{
    public class CommandResult
    {
        private CommandResult() { }

        public static CommandResult Create()
        {
            return new CommandResult
            {
                IsValid = true,
                Result = true
            };
        }

        public static CommandResult Create(IEnumerable<(string, string)> errors)
        {
            return new CommandResult
            {
                IsValid = false,
                Errors = errors
            };
        }

        public static CommandResult Create((string, string) error)
        {
            return new CommandResult
            {
                IsValid = false,
                Errors = new List<(string, string)> { error }
            };
        }

        public static CommandResult Create(object result, IEnumerable<(string, string)> errors)
        {
            return new CommandResult
            {
                IsValid = false,
                Errors = errors,
                Result = result
            };
        }

        public static CommandResult Create(IEnumerable<ValidationFailure> errors)
        {
            return Create(errors.Select(e => (e.PropertyName, e.ErrorMessage)));
        }

        public static CommandResult Create(object result, IEnumerable<ValidationFailure> errors)
        {
            return Create(result, errors.Select(e => (e.PropertyName, e.ErrorMessage)));
        }

        public static CommandResult Create(object result)
        {
            return new CommandResult
            {
                Result = result,
                IsValid = true
            };
        }

        public bool IsValid { get; set; }
        public IEnumerable<(string, string)> Errors { get; set; }
        public object Result { get; set; }
    }
}
