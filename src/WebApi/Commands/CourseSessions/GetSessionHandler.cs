using Core.Entities.CourseAggregate;
using Core.Interfaces;
using Core.Specifications;
using MediatR;
using WebApi.Commands.Courses;

namespace WebApi.Commands.CourseSessions
{
    public class GetSessionHandler : IRequestHandler<GetSession, Session>
    {
        private readonly IReadRepository<Session> _repository;

        public GetSessionHandler(IReadRepository<Session> repository)
        {
            _repository = repository;
        }
        public async Task<Session> Handle(GetSession request, CancellationToken cancellationToken)
        {
            var session = await _repository.GetByIdAsync(request.SessionId, cancellationToken);
            return session;
        }
    }
}
