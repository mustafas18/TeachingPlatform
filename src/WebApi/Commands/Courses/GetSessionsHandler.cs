using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi.ViewModels;

namespace WebApi.Commands.Courses
{
    public class GetSessionsHandler : IRequestHandler<GetSessions, List<Session>>
    {
        private readonly ICourseRepository _courseRepository;

        public GetSessionsHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<List<Session>> Handle(GetSessions request, CancellationToken cancellationToken)
        {
            var course = await  Task.Run(()=>_courseRepository
                .CourseWithSessions()
                .FirstOrDefault(s => s.Id == request.CourseId));
                               
            return course.Sessions;
        }
    }
}
