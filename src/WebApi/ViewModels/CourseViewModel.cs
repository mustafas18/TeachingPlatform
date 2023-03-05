using Core.Entities;
using Core.Entities.CourseAggregate;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.ViewModels
{
    public class CourseViewModel
    {
        public string TitleFa { get; set; }
        public string TitleEn { get; set; }
        public int Price { get; set; }
        public string Thumbnail { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
