using Account.DataAccess.Command;
using Account.DataAccess.Query;

namespace Account.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICommandStack CommandStack { get; }

        public IQueryStack QueryStack { get; }

        public UnitOfWork(IQueryStack queryStack, ICommandStack commandStack)
        {
            QueryStack = queryStack;
            CommandStack = commandStack;
        }
    }
}