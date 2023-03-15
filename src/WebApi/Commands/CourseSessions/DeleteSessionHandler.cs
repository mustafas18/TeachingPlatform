using Core.Entities;
using Core.Interfaces;
using MediatR;

namespace WebApi.Commands.CourseSessions
{
    public class DeleteSessionHandler : IRequestHandler<DeleteSession, int>
    {
        private readonly IRepository<Session> _repository;

        public DeleteSessionHandler(IRepository<Session> repository)
        {
            _repository = repository;
        }

        public int SessionId { get; }

        public Task<int> Handle(DeleteSession request, CancellationToken cancellationToken)
        {
            var session = _repository.Where(p => p.Id == request.SessionId).FirstOrDefault();
            _repository.DeleteAsync(session);
            return Task.FromResult(0);
        }
    }
}
