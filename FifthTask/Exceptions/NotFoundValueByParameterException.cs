using System;

namespace FifthTask.Exceptions
{
    public class NotFoundValueByParameterException : GetAutoByParameterException
    {
        public NotFoundValueByParameterException()
        { }

        public NotFoundValueByParameterException(string message) : base(message)
        { }

        public NotFoundValueByParameterException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
