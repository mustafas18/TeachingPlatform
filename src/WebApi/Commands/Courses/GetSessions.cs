using Core.Entities;
using MediatR;

namespace WebApi.Commands.Courses { 
    public class GetSessions:IRequest<List<Session>>
    {
    public GetSessions(int courseId)
    {
        CourseId = courseId;
    }

    public int CourseId { get; }
}
}
