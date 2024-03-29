﻿using Ardalis.Specification;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> Include(string entityName);
        T FirstOrDefault(Expression<Func<T, bool>> filter = null,
                                   Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                   string includeProperties = "");
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter = null);
        IEnumerable<T> Where(string cacheKey,Expression<Func<T, bool>> filter = null,
    Func<IEnumerable<T>, IOrderedQueryable<T>> orderBy = null,
    string includeProperties = "",
    int first = 0, int offset = 0);
    }
}
