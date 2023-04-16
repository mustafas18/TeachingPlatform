using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data.Repositories;
using MediatR;

namespace WebApi.Commands.TeachingRequest
{
    public class CreateTeachingRequestHandler : IRequestHandler<CreateTeachingRequest, TeacherRequest>
    {
        private readonly IRepository<TeacherRequest> _repository;
        private readonly IRepository<Teacher> _teacherRepository;
        private readonly IRepository<Student> _studentRepository;
        private readonly IReadRepository<Lesson> _lessonRepository;

        public CreateTeachingRequestHandler(IRepository<TeacherRequest> repository,
            IRepository<Teacher> teacherRepository,
            IRepository<Student> studentRepository,
            IReadRepository<Lesson> lessonRepository)
        {
            _repository = repository;
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
            _lessonRepository = lessonRepository;
        }
        public async Task<TeacherRequest> Handle(CreateTeachingRequest r, CancellationToken cancellationToken)
        {
            var teacher = _teacherRepository.FirstOrDefault(p => p.Id == r.RequestViewModel.TeacherId);
            var student = _studentRepository.FirstOrDefault(s => s.UserName == r.RequestViewModel.StudentUserId);
            var lesson = _lessonRepository.FirstOrDefault(l => l.NameEn == r.RequestViewModel.LessonEnName);
            TeacherRequest teacherRequest = new TeacherRequest
            {
                Description = r.RequestViewModel.Description,
                Place = r.RequestViewModel.Place,
                RequestGuid = r.RequestViewModel.RequestGuid,
                Status = r.RequestViewModel.Status,
                Type = r.RequestViewModel.Type,
                Student = student,
                Teacher = teacher,
                Lesson = lesson
            };

        await    _repository.AddAsync(teacherRequest);

            return teacherRequest;
        }
    }
}
