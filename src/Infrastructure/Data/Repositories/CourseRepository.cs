using Ardalis.Specification;
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
    public class CourseRepository:ICourseRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMemoryCache _memoryCache;

        public CourseRepository(AppDbContext dbContext,
            IMemoryCache memoryCache)
        {
            _dbContext = dbContext;
            _memoryCache = memoryCache;
        }

        public IEnumerable<Course> CourseWithStudents()
        {
            IQueryable<Course> query = _dbContext.Courses.Include(s => s.Students);
            return query;
        }
        public IEnumerable<Course> CourseWithTeachers()
        {
            IQueryable<Course> query = _dbContext.Courses.Include(s => s.Teacher);
            return query;
        }
        public IEnumerable<Course> CourseWithTeachersAndStudent()
        {
            IQueryable<Course> query = _dbContext.Courses.Include($"{nameof(Teacher)},{nameof(Student)}");
            return query;
        }
        public IEnumerable<Course> CourseWithSessions()
        {
            IQueryable<Course> query = _dbContext.Courses.Include(s => s.Sessions);
            return query;
        }
        public async Task<IEnumerable<Course>> CourseWithTeachersAsync()
        {
            IQueryable<Course> query = _dbContext.Courses.Include(s => s.Teacher);
            return query;
        }

        public Course FirstOrDefault(Expression<Func<Course, bool>> filter = null)
        {
            if (filter != null)
            {
                return _dbContext.Set<Course>().FirstOrDefault(filter);
            }
            return _dbContext.Set<Course>().FirstOrDefault();
        }
        public async Task<Course> FirstOrDefaultAsync(Expression<Func<Course, bool>> filter = null)
        {
            if (filter != null)
            {
                return await _dbContext.Set<Course>().FirstOrDefaultAsync(filter);
            }
            return await _dbContext.Set<Course>().FirstOrDefaultAsync();
        }
        public Course LastOrDefault()
        {
            return _dbContext.Set<Course>().LastOrDefault();
        }

        public IEnumerable<Course> OrderBy(Expression<Func<Course, bool>> filter = null)
        {

            {
                return _dbContext.Set<Course>().OrderBy(filter);
            }
        }

        public IEnumerable<Course> Where(Expression<Func<Course, bool>> filter = null, Func<IQueryable<Course>, IOrderedQueryable<Course>> orderBy = null, string includeProperties = "", int first = 0, int offset = 0)
        {
            if (filter != null)
            {
                return _dbContext.Set<Course>().Where(filter);
            }
            return null;

        }
    }
}
