using System;

namespace FifthTask.Exceptions
{
    public class InitializationException : ArgumentOutOfRangeException
    {
        public InitializationException()
        { }

        public InitializationException(string message) : base(message)
        { }

        public InitializationException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
