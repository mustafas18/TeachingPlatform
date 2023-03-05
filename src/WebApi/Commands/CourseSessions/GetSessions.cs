using MediatR;
using WebApi.ViewModels;

namespace WebApi.Commands.CourseSessions
{
    public class GetSessions:IRequest<SessionViewModel>
    {
        public GetSessions(int courseId)
        {
            CourseId = courseId;
        }

        public int CourseId { get; }
    }
}
