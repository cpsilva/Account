using Account.Handlers.Command;
using System.Threading.Tasks;

namespace Account.Handlers
{
    public interface ICommandDispatcher
    {
        Task<ICommandResult> Dispatch<TParameter>(TParameter command);
    }
}