using Core.Dtos;
using Core.Entities.CourseAggregate;
using MediatR;
using WebApi.ViewModels;

namespace WebApi.Commands.Courses
{
    public class GetCourse:IRequest<Course>
    {
        public GetCourse(int courseId)
        {
            CourseId = courseId;
        }

        public int CourseId { get; }
    }
}
