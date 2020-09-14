using Account.Domain;

namespace Account.DataAccess.Query
{
    public interface IQueryStack
    {
        IQueryRepository<ContaCorrente> ContaCorrente { get; }
        IQueryRepository<Lancamento> Lancamento { get; }
    }
}