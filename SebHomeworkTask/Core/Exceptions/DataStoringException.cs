namespace SebHomeworkTask.Core.Exceptions;

public class DataStoringException : Exception
{
    public DataStoringException(string message, Exception e) : base(message, e)
    {
    }
}