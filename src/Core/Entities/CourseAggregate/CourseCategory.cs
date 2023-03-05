using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.CourseAggregate
{
    [Owned]
    public class CourseCategory
    {
        public string NameFa { get; set; }
        public string NameEn { get; set; }
    }
}
