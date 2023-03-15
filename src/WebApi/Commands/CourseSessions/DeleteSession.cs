using Core.Entities;
using MediatR;

namespace WebApi.Commands.CourseSessions
{
    public class DeleteSession:IRequest<int>
    {
        public DeleteSession(int sessionId)
        {
            SessionId = sessionId;
        }

        public int SessionId { get; }
    }
}
