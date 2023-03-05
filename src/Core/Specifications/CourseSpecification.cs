using Ardalis.Specification;
using Core.Entities.CourseAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class CourseSpecification : Specification<Course>, ISingleResultSpecification
    {
        public CourseSpecification(int courseId)
        {
            Query.Where(p =>p.Id== courseId)
                .Include(p => p.Session);
        }
    }
}
