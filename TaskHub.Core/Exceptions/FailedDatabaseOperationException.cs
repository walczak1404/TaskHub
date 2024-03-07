namespace TaskHub.Core.Exceptions
{
    public class FailedDatabaseOperationException : Exception
    {
        public FailedDatabaseOperationException() : base() { }

        public FailedDatabaseOperationException(string message) : base(message) { }
    }
}
