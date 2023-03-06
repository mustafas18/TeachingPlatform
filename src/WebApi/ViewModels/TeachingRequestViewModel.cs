using Core.Entities;
using Core.Enums;

namespace WebApi.ViewModels
{
    public class TeachingRequestViewModel
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public TeachType Type { get; set; }
        public Lesson Lesson { get; set; }
        public OrderStatus Status { get; set; }
    }
}
