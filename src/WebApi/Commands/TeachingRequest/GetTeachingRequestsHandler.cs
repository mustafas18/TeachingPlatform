using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data.Repositories;
using MediatR;
using WebApi.ViewModels;

namespace WebApi.Commands.TeachingRequest
{
    public class GetTeachingRequestsHandler : IRequestHandler<GetTeachingRequests, IEnumerable<TeachingRequestViewModel>>
    {
        private readonly IReadRepository<TeacherRequest> _teachingRequestRepository;

        public GetTeachingRequestsHandler(IReadRepository<TeacherRequest> TeachingRequestRepository)
        {
            _teachingRequestRepository = TeachingRequestRepository;
        }
        public async Task<IEnumerable<TeachingRequestViewModel>> Handle(GetTeachingRequests request, CancellationToken cancellationToken)
        {
            var specification = new TeachRequestsByTeacherIdSpecification(request.TeacherId);
            var teachingRequest = await _teachingRequestRepository.ListAsync(specification, cancellationToken);

            return teachingRequest.Select(r => new TeachingRequestViewModel
            {
                TeacherId = r.Teacher.Id,
                TeacherName = r.Teacher.FullNameFa,
                Type = r.Type,
                Student = r.Student,
                Status = r.Status
            });
        }
    }
}
