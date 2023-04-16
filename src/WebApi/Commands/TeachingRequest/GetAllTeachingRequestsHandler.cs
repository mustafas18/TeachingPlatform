using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using MediatR;
using WebApi.ViewModels;

namespace WebApi.Commands.TeachingRequest
{
    public class GetAllTeachingRequestsHandler : IRequestHandler<GetAllTeachingRequests, IEnumerable<TeachingRequestViewModel>>
    {
        private readonly IReadRepository<TeacherRequest> _teachingRequestRepository;

        public GetAllTeachingRequestsHandler(IReadRepository<TeacherRequest> TeachingRequestRepository)
        {
            _teachingRequestRepository = TeachingRequestRepository;
        }
        public async Task<IEnumerable<TeachingRequestViewModel>> Handle(GetAllTeachingRequests request, CancellationToken cancellationToken)
        {
            var specification = new TeachRequestsSpecification();
            var teachingRequests = await _teachingRequestRepository.ListAsync(specification, cancellationToken);
            return teachingRequests.Select(r => new TeachingRequestViewModel
            {
                StudentUserId = r.Student.UserName,
                Description = r.Description,
                Place = r.Place,
                Type = r.Type,
                Status = r.Status
            });
        }
    }
}
