using Core.Entities;
using Core.Interfaces;
using MediatR;

namespace WebApi.Commands.Courses
{
    public class UpdateCourseHandler : IRequestHandler<UpdateCourse, Course>
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IReadRepository<CourseCategory> _categoryReadRepo;
        private readonly IReadRepository<Teacher> _teacherReadRepo;

        public UpdateCourseHandler(IRepository<Course> courseRepository,
            IReadRepository<CourseCategory> categoryReadRepo,
             IReadRepository<Teacher> teacherReadRepo)
        {
            _courseRepository = courseRepository;
            _categoryReadRepo = categoryReadRepo;
            _teacherReadRepo = teacherReadRepo;
        }

        public async Task<Course> Handle(UpdateCourse request, CancellationToken cancellationToken)
        {
            var category = _categoryReadRepo.GetByIdAsync(request.Course.CategoryId).Result;
            var teacher = _teacherReadRepo.GetByIdAsync(request.Course.TeacherId).Result;

            var course = _courseRepository.Where(p => p.Id == request.Course.Id).FirstOrDefault();

            string thumbnail = string.Empty;
            if (request.Course.ThumbnailBase46 != null)
            {
                //using var memoryStream = new MemoryStream();
                //request.CourseCreate.Thumbnail.CopyToAsync(memoryStream);
                //thumbnail = Convert.ToBase64String(memoryStream.ToArray());
                thumbnail = request.Course.ThumbnailBase46;
            }
            else
            {
                thumbnail = course.Thumbnail;
            }


            course.Category = category;
            course.Description = request.Course.Description;
            course.Duration = request.Course.Duration;
            course.Price = request.Course.Price;
            course.Thumbnail = thumbnail;
            course.TitleEn = request.Course.TitleEn;
            course.TitleFa = request.Course.TitleFa;
            course.Teacher = teacher;
            course.Sessions = request.Course.Sessions;

            await _courseRepository.UpdateAsync(course);

            return course;
        }
    }
}
