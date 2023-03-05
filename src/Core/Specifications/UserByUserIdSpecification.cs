using Ardalis.Specification;
using Core.Entities;
using Core.Entities.CourseAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class UserByUserIdSpecification : Specification<AppUser>, ISingleResultSpecification
    {
        public UserByUserIdSpecification(string userName) {
            Query.Where(u=>u.UserName== userName);
        }
    }
}
