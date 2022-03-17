using System;

namespace FifthTask.Exceptions
{
    public class AddException : Exception
    {
        public AddException()
        { }

        public AddException(string message) : base(message)
        { }

        public AddException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
