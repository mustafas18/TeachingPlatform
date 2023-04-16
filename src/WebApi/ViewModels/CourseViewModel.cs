using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string TitleFa { get; set; }
        public string TitleEn { get; set; }
        public int Price { get; set; }
        public string Duration { get; set; }
        public string Teacher { get; set; }
        public string Level { get; set; }
        public string Thumbnail { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
