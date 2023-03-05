using MediatR;
using WebApi.ViewModels;

namespace WebApi.Commands.CourseSessions
{
    public class CreateSession: IRequest<SessionViewModel>
    {
        public CreateSession(SessionViewModel session)
        {
            Session = session;
        }

        public SessionViewModel Session { get; }
    }
}
