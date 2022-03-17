using System;

namespace FifthTask.Exceptions
{
    public class AmbiguousMatchException : GetAutoByParameterException
    {
        public AmbiguousMatchException()
        { }

        public AmbiguousMatchException(string message) : base(message)
        { }

        public AmbiguousMatchException(string message, Exception innerException) : base (message, innerException)
        { }
    }
}
