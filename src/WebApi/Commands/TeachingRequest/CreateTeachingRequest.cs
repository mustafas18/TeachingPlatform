using Core.Entities;
using MediatR;
using WebApi.ViewModels;

namespace WebApi.Commands.TeachingRequest
{
    public class CreateTeachingRequest : IRequest<TeacherRequest>
    {
        public CreateTeachingRequest(CreateTeachingRequestViewModel requestViewModel)
        {
            RequestViewModel = requestViewModel;
        }

        public CreateTeachingRequestViewModel RequestViewModel { get; }
    }
}
