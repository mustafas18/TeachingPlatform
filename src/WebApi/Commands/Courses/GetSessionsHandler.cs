using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using MediatR;
using WebApi.ViewModels;

namespace WebApi.Commands.Courses
{
    public class GetSessionsHandler : IRequestHandler<GetSessions, List<Session>>
    {
        private readonly IReadRepository<Session> _readRepository;

        public GetSessionsHandler(IReadRepository<Session> readRepository)
        {
            _readRepository = readRepository;
        }
        public async Task<List<Session>> Handle(GetSessions request, CancellationToken cancellationToken)
        {
            var specification = new SessionListByCourseId(request.CourseId);
            var sessions = await _readRepository.ListAsync(specification, cancellationToken);
            return sessions;
        }
    }
}
