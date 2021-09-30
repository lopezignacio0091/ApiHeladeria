using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Positano.Application
{
    public abstract class QueryResult
    {
        public void Create(IEnumerable<(string, string)> errors)
        {
            Errors = errors;
            IsValid = false;
        }

        public void Create((string, string) error)
        {
            Errors = new List<(string, string)> { error };
            IsValid = false;
        }

        public void Create(IEnumerable<ValidationFailure> errors)
        {
            Create(errors.Select(e => (e.PropertyName, e.ErrorMessage)));
        }

        public bool IsValid { get; set; } = true;
        public IEnumerable<(string key, string error)> Errors { get; set; }
    }
}
