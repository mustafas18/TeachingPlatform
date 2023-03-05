using Core.Dtos;
using MediatR;
using WebApi.ViewModels;

namespace WebApi.Commands.Courses
{
    public class GetAllCourses:IRequest<IEnumerable<CourseViewModel>>
    {
        public GetAllCourses()
        {

        }
    }
}
