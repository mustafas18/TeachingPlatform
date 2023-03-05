using MediatR;
using WebApi.ViewModels;

namespace WebApi.Commands.TeachingRequest
{
    public class GetAllTeachingRequests : IRequest<IEnumerable<TeachingRequestViewModel>>
    {
        public GetAllTeachingRequests()
        {

        }
    }
}
