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

        public async Task<Course> CourseWithSession(int id)
        {
            return await _context.Courses.Include(p => p.Sessions)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }
    }
}
