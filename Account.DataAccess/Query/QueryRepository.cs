﻿using Account.DataAccess.Database.Context;
using Account.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Account.DataAccess.Query
{
    public class QueryRepository<T> : IQueryRepository<T> where T : BaseDomain
    {
        private readonly DatabaseContext _dbContext;

        internal QueryRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Contar(Expression<Func<T, bool>> predicate)
        {
            return _dbContext
                .Set<T>()
                .Where(predicate)
                .AsNoTracking()
                .Count();
        }

        public bool Existe(Expression<Func<T, bool>> predicate)
        {
            return _dbContext
                .Set<T>()
                .AsNoTracking()
                .Any(predicate);
        }

        public List<T> Listar()
        {
            return _dbContext
                .Set<T>()
                .AsNoTracking()
                .ToList();
        }

        public T Selecionar(Expression<Func<T, bool>> predicate)
        {
            return _dbContext
                .Set<T>()
                .AsNoTracking()
                .SingleOrDefault(predicate);
        }

        public T Selecionar(int id)
        {
            return _dbContext
                .Set<T>()
                .Find(id);
        }
    }
}