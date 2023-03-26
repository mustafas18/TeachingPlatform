using Core.Entities;
using MediatR;
using WebApi.ViewModels;

namespace WebApi.Commands.Courses
{
    public class UpdateCourse:IRequest<Course>
    {
        public UpdateCourse(CourseCreateViewModel course)
        {
            Course = course;
        }

        public CourseCreateViewModel Course { get; }
    }
}
