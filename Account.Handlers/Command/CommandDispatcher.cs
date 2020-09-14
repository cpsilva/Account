using Account.DependencyInjection;
using System.Threading.Tasks;

namespace Account.Handlers.Command
{
    public class CommandDispatcher : ICommandDispatcher
    {
        public CommandDispatcher()
        {
        }

        public async Task<ICommandResult> Dispatch<TParameter>(TParameter command)
        {
            var handler = Container.GetService<ICommandHandler<TParameter>>();
            if (handler != null)
            {
                return await handler.Execute(command);
            }

            return CommandResult.AnyHandlerFound<TParameter>();
        }
    }
}