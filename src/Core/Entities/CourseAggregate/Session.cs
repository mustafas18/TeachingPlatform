using Core.Enums;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.CourseAggregate
{
    public class Session : BaseEntity, IAggregateRoot
    {
        public string TitleFa { get; set; }
        public string TitleEn { get; set; }
        public Course Course { get; set; }
        //public Section Section { get; set; }
        public SessionType SessionType { get; set; } = SessionType.Video;
        /// <summary>
        /// Duriation in second
        /// </summary>
        public int Duration { get; set; }
        public string Thumbnail { get; set; }
        public string ResourceUri { get; set; }
        public int OrderNumber { get; set; }
    }
}
