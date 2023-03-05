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
                TeacherId = r.Teacher.Id,
                TeacherName = r.Teacher.FullNameFa,
                Type = r.Type,
                Lesson = r.Lesson,
                Student = r.Student,
                Status = r.Status
            });
        }
    }
}
