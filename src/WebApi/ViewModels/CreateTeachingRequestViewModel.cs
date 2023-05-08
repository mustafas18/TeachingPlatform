using Core.Enums;

namespace WebApi.ViewModels
{
    public class CreateTeachingRequestViewModel
    {
        public string UserName { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string LessonEnName { get; set; }
        public TeachType Type { get; set; }
        public string Place { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        public DateTime RequestDateTime { get; set; }
        public string RequestGuid { get; set; }
        public OrderStatus Status { get; set; }
    }
}
