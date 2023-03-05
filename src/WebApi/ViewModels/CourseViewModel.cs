using Core.Entities;
using Core.Entities.CourseAggregate;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.ViewModels
{
    public class CourseViewModel
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
        public string Thumnail { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
