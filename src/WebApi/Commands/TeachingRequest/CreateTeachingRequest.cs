using Core.Entities;
using MediatR;
using WebApi.ViewModels;

namespace WebApi.Commands.TeachingRequest
{
    public class CreateTeachingRequest : IRequest<TeacherRequest>
    {
        public CreateTeachingRequest(TeachingRequestViewModel requestViewModel)
        {
            RequestViewModel = requestViewModel;
        }

        public TeachingRequestViewModel RequestViewModel { get; }
    }
}
