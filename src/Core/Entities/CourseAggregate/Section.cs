using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.CourseAggregate
{
    public class Section : BaseEntity
    {
        public string TitleFa { get; set; }
        public string TitleEn { get; set; }
        public Course Course { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public int OrderNumber { get; set; }
    }
}
