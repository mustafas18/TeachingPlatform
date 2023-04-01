using MediatR;
using WebApi.ViewModels.Acconut;

namespace WebApi.Commands.Account
{
    public class CheckCourseStudent : IRequest<bool>
    {
        public CheckCourseStudent(CourseStudentViewModel courseStudent)
        {
            CourseStudent = courseStudent;
        }

        public CourseStudentViewModel CourseStudent { get; }
    }
}
