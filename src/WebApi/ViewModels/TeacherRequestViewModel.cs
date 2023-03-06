using Core.Enums;

namespace WebApi.ViewModels
{
    public class TeacherRequestViewModel
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string StudentUserId { get; set;}
        public int LessonId { get; set; }
        public TeachType TeachingType { get; set;}

    }
}
