namespace Account.Domain
{
    public class Result
    {
        public Result(bool success, string message = null)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; private set; }

        public string Message { get; set; }
    }
}