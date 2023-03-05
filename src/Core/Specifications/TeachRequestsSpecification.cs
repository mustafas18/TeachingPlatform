using Ardalis.Specification;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class TeachRequestsSpecification : Specification<TeacherRequest>, ISingleResultSpecification
    {
        public TeachRequestsSpecification() {

            Query.AsNoTracking(true);
        }

    }
}
