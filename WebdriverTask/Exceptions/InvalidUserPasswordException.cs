namespace WebdriverTask.Exceptions;

public class InvalidUserPasswordException : InvalidUserCredentialsException
{
    public InvalidUserPasswordException(string message) : base(message)
    {
        
    }
}