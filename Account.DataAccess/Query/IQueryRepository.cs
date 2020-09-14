using Account.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Account.DataAccess.Query
{
    public interface IQueryRepository<T> where T : BaseDomain
    {
        int Contar(Expression<Func<T, bool>> predicate);

        bool Existe(Expression<Func<T, bool>> predicate);

        List<T> Listar();

        T Selecionar(Expression<Func<T, bool>> predicate);

        T Selecionar(int id);
    }
}