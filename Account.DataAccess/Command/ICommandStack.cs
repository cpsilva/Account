using Account.Domain;

namespace Account.DataAccess.Command
{
    public interface ICommandStack
    {
        ICommandRepository<ContaCorrente> ContaCorrente { get; }
        ICommandRepository<Lancamento> Lancamento { get; }

        void SaveChanges();
    }
}