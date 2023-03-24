using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi.Commands.TeachingRequest;
using WebApi.ViewModels;

namespace WebApi.Commands.Courses
{
    public class GetAllCoursesHandler : IRequestHandler<GetAllCourses, IEnumerable<CourseViewModel>>
    {
        private readonly IReadRepository<Course> _courseRepository;

        public GetAllCoursesHandler(IReadRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<IEnumerable<CourseViewModel>> Handle(GetAllCourses request, CancellationToken cancellationToken)
        {
            var courses = await _courseRepository.Include("Teacher").ToListAsync();
            return courses.Select(c => new CourseViewModel
            {
                Id = c.Id,
                CreatedTime = c.CreatedTime,
                Price = c.Price,
                Thumbnail = c.Thumbnail,
                TitleEn = c.TitleEn,
                TitleFa = c.TitleFa,
                Teacher=c.Teacher.FullNameFa,
                Duration = $"{c.Duration / 60} دقیقه",
                Level = c.Level.ToString()
            });
            ;
        }
    }
}
