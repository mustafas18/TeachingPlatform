using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Course : BaseEntity, IAggregateRoot
    {
        public string TitleFa { get; set; }
        public string TitleEn { get; set; }
        public CourseCategory Category { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        /// <summary>
        /// Duriation in second
        /// </summary>
        public int Duration { get; set; }
        public string Thumbnail { get; set; }

        //[InverseProperty(nameof(Course))]
        //public ICollection<Section> Sections { get; set; }
        public virtual List<Session> Sessions { get; set; }
        public ICollection<Student> Students { get; set; }
        public Teacher Teacher { get; set; }
        public DateTime CreatedTime { get; set; }

    }
}
