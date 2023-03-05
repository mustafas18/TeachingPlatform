using Core.Entities.CourseAggregate;
using MediatR;
using WebApi.ViewModels;

namespace WebApi.Commands.Courses
{
    public class CreateCourse:IRequest<Course>
    {
        public CreateCourse(CourseCreateViewModel courseCreate)
        {
            CourseCreate = courseCreate;
        }

        public CourseCreateViewModel CourseCreate { get; }
    }
}
