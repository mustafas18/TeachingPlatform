using Core.Dtos;
using Core.Entities;
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
