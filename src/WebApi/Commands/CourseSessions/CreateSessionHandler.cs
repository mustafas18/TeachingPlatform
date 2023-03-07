using Core.Entities;
using Core.Interfaces;
using MediatR;

namespace WebApi.Commands.CourseSessions
{
    public class CreateSessionHandler : IRequestHandler<CreateSession, Session>
    {
        private readonly IReadRepository<Course> _courseReadRepository;
        private readonly IRepository<Session> _sessionRepo;

        public CreateSessionHandler(IReadRepository<Course> courseReadRepository,
            IRepository<Session> sessionRepo)
        {
            _courseReadRepository = courseReadRepository;
            _sessionRepo = sessionRepo;
        }
        public Task<Session> Handle(CreateSession request, CancellationToken cancellationToken)
        {
            var course = _courseReadRepository.GetByIdAsync(request.Session.CourseId).Result;

            var session = new Session
            {
                SessionType = request.Session.SessionType,
                Thumbnail = request.Session.Thumbnail,
                TitleEn = request.Session.TitleEn,
                TitleFa = request.Session.TitleFa,
                Course = course,
                Duration = request.Session.Duration,
                OrderNumber = request.Session.OrderNumber,
                ResourceUri = request.Session.ResourceUri,
            };
            _sessionRepo.AddAsync(session);
            return Task.FromResult(session);
        }
    }
}
