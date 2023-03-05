using Ardalis.Specification;
using Core.Entities.CourseAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class SessionSpecification : Specification<Session>, ISingleResultSpecification
    {
        public SessionSpecification(int sessionId)
        {
            Query.Where(p => p.Id == sessionId);

        }
    }
}
