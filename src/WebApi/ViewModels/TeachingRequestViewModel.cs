using Core.Entities;
using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels
{
    public class TeachingRequestViewModel
    {
        public string StudentUserId { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string LessonEnName { get; set; }
        public TeachType Type { get; set; }
        public string Place { get; set; }
        public string? Description { get; set; }
        public string RequestGuid { get; set; }
        public OrderStatus Status { get; set; }
        public Lesson Lesson { get; set; }
        public Student Student { get; set; }
    }
}
