using MediatR;
using Core.Entities.CourseAggregate;
using WebApi.ViewModels;

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
