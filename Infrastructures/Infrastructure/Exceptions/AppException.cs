namespace Infrastructure.Exceptions
{
    using System;

    public class AppException : Exception
    {
        public AppException(string message = default, Exception innerException = default) : base(message, innerException)
        {
        }
    }
}
