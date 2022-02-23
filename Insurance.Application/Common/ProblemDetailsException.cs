using Insurance.Application.Common;

namespace Insurance.Application
{
    public class ProblemDetailsException : Exception
    {
        public readonly IDictionary<string, string[]>? Errors;

        public ProblemDetailsException()
        {
        }

        public ProblemDetailsException(string message) : base(message)
        {
        }

        public ProblemDetailsException(string message, Exception inner) : base(message, inner)
        {
        }

        public ProblemDetailsException(IDictionary<string, string[]> errors)
        {
            Errors = errors.ToDictionary(k => k.Key[(k.Key.IndexOf('.') + 1)..].ToSnakeCase(), k => k.Value);
        }

    }
}
