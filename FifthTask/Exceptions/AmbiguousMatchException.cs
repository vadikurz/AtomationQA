namespace FifthTask.Exceptions
{
    public class AmbiguousMatchException : GetAutoByParameterException
    {
        public AmbiguousMatchException(string message) : base(message)
        {

        }
    }
}
