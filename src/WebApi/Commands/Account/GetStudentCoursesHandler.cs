using Core.Entities;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi.ViewModels;

namespace WebApi.Commands.Account
{
    public class GetStudentCoursesHandler : IRequestHandler<GetStudentCourses, List<CourseViewModel>>
    {
        private readonly IReadRepository<Course> _courseRepository;
        private readonly IReadRepository<Student> _studentRepository;

        public GetStudentCoursesHandler(IReadRepository<Course> courseRepository,
            IReadRepository<Student> studentRepository)
        {
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
        }
        public async Task<List<CourseViewModel>> Handle(GetStudentCourses request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.FirstOrDefaultAsync(s => s.UserName == request.UserName);
            var courses = await _courseRepository
                  .Where(p => p.Students.Contains(student))
                  .Include("Students").Select(s => new CourseViewModel
                  {
                      TitleFa = s.TitleFa,
                      TitleEn = s.TitleEn,
                      CreatedTime = s.CreatedTime,
                      Duration = (int)(s.Duration / 360)==0? $"{(int)(s.Duration / 60)} دقیقه" : $"{(int)(s.Duration /360)} ساعت و {(int)((s.Duration % 360) /60)} دقیقه",
                      Id = s.Id,
                      Level = (int)s.Level,
                      Price = s.Price,
                      Thumbnail=s.Thumbnail,
                      Teacher=s.Teacher.FullNameFa
                  }).ToListAsync();


            return courses;
        }
    }
}
