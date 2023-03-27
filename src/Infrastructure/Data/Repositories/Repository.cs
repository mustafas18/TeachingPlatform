using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
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

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
           _context.Set<TEntity>().Update(entity);
           await _context.SaveChangesAsync();
            return entity;
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
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter != null)
            {
                return _context.Set<TEntity>().FirstOrDefault(filter);
            }
            return _context.Set<TEntity>().FirstOrDefault();


        }

        public IQueryable<TEntity> Include(string entityName)
        {
            return _context.Set<TEntity>().Include(entityName);
        }
    }
}
