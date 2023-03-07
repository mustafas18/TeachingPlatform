using MediatR;
using WebApi.ViewModels;
using Core.Entities;

namespace WebApi.Commands.CourseSessions
{
    public class CreateSession: IRequest<Session>
    {
        public CreateSession(SessionViewModel session)
        {
            Session = session;
        }

        public SessionViewModel Session { get; }
    }
}
