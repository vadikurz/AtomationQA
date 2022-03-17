using System;

namespace FifthTask.Exceptions
{
    public class NotFoundParameterException : GetAutoByParameterException
    {
        public NotFoundParameterException()
        { }

        public NotFoundParameterException(string message) : base(message)
        { }

        public NotFoundParameterException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
