using Core.Entities;
using MediatR;
using WebApi.ViewModels;

namespace WebApi.Commands.Account
{
    public class GetStudentCourses:IRequest<List<CourseViewModel>>
    {
        public GetStudentCourses(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; }
    }
}
