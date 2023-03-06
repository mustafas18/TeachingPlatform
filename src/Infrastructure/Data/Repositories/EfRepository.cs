using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Core.Entities.CourseAggregate;
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
    public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T> where T : class, IAggregateRoot
    {
        private readonly AppDbContext _context;

        public EfRepository(AppDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<Course> CourseWithSession(int id)
        {
            return await _context.Courses.Include(p => p.Sessions)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
