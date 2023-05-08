using Core.Dtos;
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
        private readonly IEmailService _emailService;

        public CreateTeachingRequestHandler(IRepository<TeacherRequest> repository,
            IRepository<Teacher> teacherRepository,
            IRepository<Student> studentRepository,
            IReadRepository<Lesson> lessonRepository,
            IEmailService emailService)
        {
            _repository = repository;
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
            _lessonRepository = lessonRepository;
            _emailService = emailService;
        }
        public async Task<TeacherRequest> Handle(CreateTeachingRequest r, CancellationToken cancellationToken)
        {
            var teacher = _teacherRepository.FirstOrDefault(p => p.Id == r.RequestViewModel.TeacherId);
            var student = _studentRepository.FirstOrDefault(s => s.UserName == r.RequestViewModel.UserName);
            var lesson = _lessonRepository.FirstOrDefault(l => l.NameEn == r.RequestViewModel.LessonEnName);
            var now = DateTime.Now;
            TeacherRequest teacherRequest = new TeacherRequest
            {
                Description = r.RequestViewModel.Description,
                Place = r.RequestViewModel.Place,
                RequestGuid = r.RequestViewModel.RequestGuid,
                Status = r.RequestViewModel.Status,
                Type = r.RequestViewModel.Type,
                Student = student,
                Teacher = teacher,
                Lesson = lesson,
                RequestTime = now,
                Price = r.RequestViewModel.Price
            };

            Task.Factory.StartNew(async () =>
            {
              await  _repository.AddAsync(teacherRequest);
            }, creationOptions: TaskCreationOptions.LongRunning);
           

            _emailService.SendEmailAsync(new EmailDto
            {
                From = "noreply@api.ielts-zi.ir",
                To = "mostafabazghandi2001@gmail.com",
                Subject = $"درخواست معلم خصوصی توسط {student?.UserName}-{Guid.NewGuid().ToString().Substring(1, 4)}",
                Body = $"درخواست معلم خصوصی توسط {student?.UserName} در تاریخ {now}",
                Time = now
            });

            return teacherRequest;
        }
    }
}
