using System;

namespace FifthTask.Exceptions
{
    public class InitializationException : ArgumentOutOfRangeException
    {
        public InitializationException(string message) : base(message)
        {

        }
    }
}
