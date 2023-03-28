using Core.Entities;
using MediatR;

namespace WebApi.Commands.Account
{
    public class SignUpCourse:IRequest<Course>
    {
        public SignUpCourse(string studentUserName,int courseId)
        {
            StudentUserName = studentUserName;
            CourseId = courseId;
        }

        public string StudentUserName { get; set; }
        public int CourseId { get; set; }
    }
}
