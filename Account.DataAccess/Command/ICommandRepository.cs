using Account.Domain;

namespace Account.DataAccess.Command
{
    public interface ICommandRepository<T> where T : BaseDomain
    {
        void Apagar(int id);

        void Adicionar(T entity);

        void Atualizar(T entity);
    }
}