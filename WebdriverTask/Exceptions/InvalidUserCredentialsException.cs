using System;

namespace WebdriverTask.Exceptions;

public class InvalidUserCredentialsException : Exception
{
    public InvalidUserCredentialsException(string message) : base(message)
    {
        
    }
}