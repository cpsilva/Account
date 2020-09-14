using Account.DataAccess.Database.Context;
using Account.Domain;

namespace Account.DataAccess.Query
{
    public class QueryStack : IQueryStack
    {
        private readonly DatabaseContext DatabaseContext;

        public IQueryRepository<ContaCorrente> ContaCorrente { get; }

        public IQueryRepository<Lancamento> Lancamento { get; }

        public QueryStack(DatabaseContext databaseContext)
        {
            databaseContext.Database.EnsureCreated();

            DatabaseContext = databaseContext;

            ContaCorrente = new QueryRepository<ContaCorrente>(DatabaseContext);
            Lancamento = new QueryRepository<Lancamento>(DatabaseContext);
        }
    }
}