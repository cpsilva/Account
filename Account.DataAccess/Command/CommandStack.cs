using Account.DataAccess.Database.Context;
using Account.Domain;

namespace Account.DataAccess.Command
{
    public class CommandStack : ICommandStack
    {
        public CommandStack(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;

            ContaCorrente = new CommandRepository<ContaCorrente>(DatabaseContext);
            Lancamento = new CommandRepository<Lancamento>(DatabaseContext);
        }

        public ICommandRepository<ContaCorrente> ContaCorrente { get; }
        public ICommandRepository<Lancamento> Lancamento { get; }
        private DatabaseContext DatabaseContext { get; }

        public void SaveChanges()
        {
            DatabaseContext.SaveChanges();
        }
    }
}