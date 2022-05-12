namespace WebdriverTask.Exceptions;

public class InvalidUserLoginException : InvalidUserCredentialsException
{
    public InvalidUserLoginException(string message) : base(message)
    {
        
    }
}