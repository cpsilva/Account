using Account.DataAccess.Database.Context;
using Account.Domain;
using Microsoft.EntityFrameworkCore;

namespace Account.DataAccess.Command
{
    public class CommandRepository<T> : ICommandRepository<T> where T : BaseDomain
    {
        private readonly DatabaseContext _dbContext;

        public CommandRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Adicionar(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void Atualizar(T entity)
        {
            var e = _dbContext.Entry(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Apagar(int id)
        {
            var entityTrackeable = _dbContext.Set<T>().Find(id);
            if (entityTrackeable == null) { return; }
            _dbContext.Set<T>().Remove(entityTrackeable);
        }
    }
}