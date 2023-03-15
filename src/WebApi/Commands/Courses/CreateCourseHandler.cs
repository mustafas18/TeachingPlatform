using Core.Entities;
using Core.Interfaces;
using MediatR;
using WebApi.ViewModels;

namespace WebApi.Commands.Courses
{
    public class CreateCourseHandler : IRequestHandler<CreateCourse, Course>
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IReadRepository<CourseCategory> _categoryReadRepo;
        private readonly IReadRepository<Teacher> _teacherReadRepo;

        public CreateCourseHandler(IRepository<Course> courseRepository,
            IReadRepository<CourseCategory> categoryReadRepo,
             IReadRepository<Teacher> teacherReadRepo)
        {
            _courseRepository = courseRepository;
            _categoryReadRepo = categoryReadRepo;
            _teacherReadRepo = teacherReadRepo;
        }
        public async Task<Course> Handle(CreateCourse request, CancellationToken cancellationToken)
        {
            var category = _categoryReadRepo.GetByIdAsync(request.CourseCreate.CategoryId).Result;
            var teacher = _teacherReadRepo.GetByIdAsync(request.CourseCreate.TeacherId).Result;

            using var memoryStream = new MemoryStream();
                 request.CourseCreate.Thumbnail.CopyToAsync(memoryStream);
               var thumbnail = Convert.ToBase64String(memoryStream.ToArray());

            var course = new Course
            {
                Category = category,
                CreatedTime = DateTime.UtcNow,
                Description = request.CourseCreate.Description,
                Duration = request.CourseCreate.Duration,
                Price = request.CourseCreate.Price,
                Thumbnail = thumbnail,
                TitleEn = request.CourseCreate.TitleEn,
                TitleFa = request.CourseCreate.TitleFa,
                Teacher = teacher
            };
         _courseRepository.AddAsync(course);
            return course;
        }
    }
}
