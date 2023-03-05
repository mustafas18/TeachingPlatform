using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.CourseAggregate
{
    public class CourseCategory : BaseEntity, IAggregateRoot
    {
        public string NameFa { get; set; }
        public string NameEn { get; set; }
    }
}
