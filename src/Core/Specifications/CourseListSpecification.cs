using Ardalis.Specification;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class CourseListSpecification : Specification<Course>, ISingleResultSpecification
    {
        public CourseListSpecification()
        {
            Query.OrderByDescending(p => p.CreatedTime);
        }
    }
}
