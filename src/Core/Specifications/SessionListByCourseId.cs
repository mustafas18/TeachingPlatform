using Ardalis.Specification;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class SessionListByCourseId : Specification<Session>, ISingleResultSpecification
    {
        public SessionListByCourseId(int courseId)
        {
            Query.Where(p => p.Course.Id == courseId);
        }
    }
}
