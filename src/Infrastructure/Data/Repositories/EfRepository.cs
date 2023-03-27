using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public EfRepository(AppDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
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
        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }
        public async  Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        public IQueryable<TEntity> Include(string entityName)
        {
            return _context.Set<TEntity>().Include(entityName);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filter = null,
                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                            string includeProperties = "",
                            int first = 0, int offset = 0)
        {
            if (filter != null)
            {
                return _context.Set<TEntity>().Where(filter);
            }
            return null;


        }

    }
}
