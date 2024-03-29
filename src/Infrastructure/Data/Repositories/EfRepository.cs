﻿using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Azure.Core;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    // inherit from Ardalis.Specification type
    public class EfRepository<TEntity> : RepositoryBase<TEntity>, IReadRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        private readonly AppDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public EfRepository(AppDbContext dbContext,
            IMemoryCache memoryCache) : base(dbContext)
        {
            _context = dbContext;
            _memoryCache = memoryCache;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public async Task AddAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }


        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter = null,
                                   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                   string includeProperties = "")
        {
            if (filter != null)
            {
                return _context.Set<TEntity>().FirstOrDefault(filter);
            }
            return null;


        }
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter != null)
            {
                return await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
            }
            return null;


        }
        public IEnumerable<TEntity> GetAll()
        {
            return _memoryCache.GetOrCreate($"GetAll{nameof(TEntity)}", entity =>
            {
                entity.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(1);
                return _context.Set<TEntity>().ToList();
            });    
        }
        async Task<IEnumerable<TEntity>> IReadRepository<TEntity>.GetAllAsync()
        {
                return await _context.Set<TEntity>().ToListAsync();
        }
        public async  Task<List<TEntity>> GetAllAsync()
        {
            return await _memoryCache.GetOrCreate($"GetAllAsync{nameof(TEntity)}", entity =>
            {
                entity.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(1);
                return _context.Set<TEntity>().ToListAsync();
            });
        }
        public IEnumerable<TEntity> Include(string entityProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            foreach (var includeProperty in entityProperties.Split(",", StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return query;
        }


        public IEnumerable<TEntity> Where(string cacheKey,Expression<Func<TEntity, bool>> filter = null,
                            Func<IEnumerable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                            string includeProperties = "",
                            int first = 0, int offset = 0)
        {
            return _memoryCache.GetOrCreate(cacheKey, entity =>
            {
                entity.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(1);
                if (filter != null)
                {
                    return _context.Set<TEntity>().Where(filter);
                }
                return null;
            });

        }

       
    }
}
