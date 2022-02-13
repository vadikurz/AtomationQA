using System;

namespace FifthTask.Exceptions
{
    public class GetAutoByParameterException : ArgumentException
    {
        public GetAutoByParameterException(string message) : base(message)
        {

        }
    }
}
