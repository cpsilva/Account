using Account.DataAccess.Command;
using Account.DataAccess.Query;

namespace Account.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICommandStack CommandStack { get; }
        IQueryStack QueryStack { get; }
    }
}