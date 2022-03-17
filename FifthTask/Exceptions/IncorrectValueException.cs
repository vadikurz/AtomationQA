using System;

namespace FifthTask.Exceptions
{
    public class IncorrectValueException : InitializationException
    {
        public IncorrectValueException()
        { }

        public IncorrectValueException(string message) : base(message)
        { }

        public IncorrectValueException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
