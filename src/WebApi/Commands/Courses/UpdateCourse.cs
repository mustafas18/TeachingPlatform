using Core.Entities;
using MediatR;

namespace WebApi.Commands.Courses
{
    public class UpdateCourse:IRequest<Course>
    {
        public UpdateCourse(Course course)
        {
            Course = course;
        }

        public Course Course { get; }
    }
}
