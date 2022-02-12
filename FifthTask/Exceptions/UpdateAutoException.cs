using System;

namespace FifthTask.Exceptions
{
    public class UpdateAutoException : ArgumentException
    {
        public UpdateAutoException(string message) : base(message)
        {

        }
    }
}
