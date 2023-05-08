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
            var teachingRequests = _teachingRequestRepository.Include("Student,Lesson,Teacher").ToList();
            return teachingRequests.Select(r => new TeachingRequestViewModel
            {
                Student = r.Student,
                Description = r.Description,
                Place = r.Place,
                Price = r.Price,
                LessonEnName = r.Lesson?.NameEn,
                TeacherName = r.Teacher?.FullNameEn,
                RequestDateTime = r.RequestTime,
                Type = r.Type,
                Status = r.Status
            });
        }
    }
}
