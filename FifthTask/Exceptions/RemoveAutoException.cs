using System;

namespace FifthTask.Exceptions
{
    public class RemoveAutoException : ArgumentException
    {
        public RemoveAutoException(string message) : base(message)
        {

        }
    }
}
