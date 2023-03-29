using MediatR;
using WebApi.ViewModels.Acconut;

namespace WebApi.Commands.Account
{
    public class IsCourseStudent:IRequest<bool>
    {
        public IsCourseStudent(CourseStudentViewModel courseStudent)
        {
            CourseStudent = courseStudent;
        }

        public CourseStudentViewModel CourseStudent { get; }
    }
}
