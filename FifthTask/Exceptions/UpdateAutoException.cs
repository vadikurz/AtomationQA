using System;

namespace FifthTask.Exceptions
{
    public class UpdateAutoException : Exception
    {
        public UpdateAutoException()
        { }

        public UpdateAutoException(string message) : base(message)
        { }

        public UpdateAutoException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
