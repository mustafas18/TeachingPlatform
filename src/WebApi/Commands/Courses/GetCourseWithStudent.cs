using Core.Entities;
using MediatR;

namespace WebApi.Commands.Courses
{
    public class GetCourseWithStudent:IRequest<Course>
    {
        public GetCourseWithStudent(int courseId)
        {
            CourseId = courseId;
        }

        public int CourseId { get; }
    }
}
