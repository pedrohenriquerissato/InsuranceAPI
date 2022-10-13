using Insurance.Application.Common;
using System.Collections.Immutable;

namespace Insurance.Application
{
    public class ProblemDetailsException : Exception
    {
        public readonly ImmutableDictionary<string, string[]>? Errors;

        public ProblemDetailsException()
        {
        }

        public ProblemDetailsException(string message) : base(message)
        {
        }

        public ProblemDetailsException(string message, Exception inner) : base(message, inner)
        {
        }

        public ProblemDetailsException(ImmutableDictionary<string, string[]> errors)
        {
            Errors = errors.ToImmutableDictionary(k => k.Key[(k.Key.IndexOf('.') + 1)..].ToSnakeCase(), k => k.Value);
        }
    }
}
