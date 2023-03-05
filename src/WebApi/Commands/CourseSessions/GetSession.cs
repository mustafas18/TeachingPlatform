using Core.Entities.CourseAggregate;
using MediatR;
using WebApi.ViewModels;

namespace WebApi.Commands.CourseSessions
{
    public class GetSession:IRequest<Session>
    {
        public GetSession(int sessionId)
        {
            SessionId = sessionId;
        }

        public int SessionId { get; }
    }
}
