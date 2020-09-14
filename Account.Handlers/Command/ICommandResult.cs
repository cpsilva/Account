namespace Account.Handlers.Command
{
    public interface ICommandResult
    {
        bool Success { get; }
        string Message { get; set; }
        object Data { get; set; }
    }

    public interface ICommandResult<TResult> : ICommandResult
    {
        new TResult Data { get; set; }
    }
}