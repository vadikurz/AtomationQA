using System;

namespace FifthTask.Exceptions
{
    public class AddException : ArgumentException
    {
        public AddException(string message) : base(message)
        {

        }
    }
}
