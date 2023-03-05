using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using Core.Entities;

namespace Core.Specifications
{
    public class TeachRequestsByTeacherIdSpecification : Specification<TeacherRequest>, ISingleResultSpecification
    {
        public TeachRequestsByTeacherIdSpecification(int teacherId)
        {

            Query.Include(t => t.Teacher)
                .Where(t => t.Teacher.Id == teacherId);
               
        }
    }
}
