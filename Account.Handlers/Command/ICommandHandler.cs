using System.Threading.Tasks;

namespace Account.Handlers.Command
{
    public interface ICommandHandler<in TParameter>
    {
        Task<CommandResult> Execute(TParameter command);
    }

    public interface ICommandHandler<in TParameter, TResult> where TResult : ICommandResult
    {
        Task<TResult> Execute(TParameter command);
    }
}