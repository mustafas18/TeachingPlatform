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
        private readonly IReadRepository<Course> _readRepository;

        public GetSessionsHandler(IReadRepository<Course> readRepository)
        {
            _readRepository = readRepository;
        }
        public async Task<List<Session>> Handle(GetSessions request, CancellationToken cancellationToken)
        {
            var course = await _readRepository
                .Include("Sessions")
                .FirstOrDefaultAsync(s => s.Id == request.CourseId);
                               
            return course.Sessions;
        }
    }
}
