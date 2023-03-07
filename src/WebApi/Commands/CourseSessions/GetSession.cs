using Core.Entities;
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
