using Ardalis.Specification;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    /// <summary>
    /// IEnumerable: The filtering will take place in memory. Using IEnumerable<T> interface in IQueryable<T> fashion as in the example above will load a lot of redundant data from the table, causing performance issues. In our case, all users from the table will be loaded into memory, although only active users are needed.
    ///The IQueryable<T> interface and related code is encapsulated in the repository. It removes the complexity from the consumers of the repository as they only deal with regular .NET collections.
    /// </summary>
    public interface ICourseRepository
    {
        IEnumerable<Course> CourseWithStudents();
        IEnumerable<Course> CourseWithTeachers();
        IEnumerable<Course> CourseWithSessions();
        Task<IEnumerable<Course>> CourseWithTeachersAsync();
        IEnumerable<Course> CourseWithTeachersAndStudent();
        IEnumerable<Course> Where(Expression<Func<Course, bool>> filter = null,
        Func<IQueryable<Course>, IOrderedQueryable<Course>> orderBy = null,
           string includeProperties = "",
           int first = 0, int offset = 0);
        Course FirstOrDefault(Expression<Func<Course, bool>> filter = null);
        Task<Course> FirstOrDefaultAsync(Expression<Func<Course, bool>> filter = null);
        Course LastOrDefault();
        IEnumerable<Course> OrderBy(Expression<Func<Course, bool>> filter = null);

    }
}
