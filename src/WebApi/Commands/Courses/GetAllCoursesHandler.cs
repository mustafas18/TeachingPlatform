using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WebApi.Commands.TeachingRequest;
using WebApi.ViewModels;

namespace WebApi.Commands.Courses
{
    public class GetAllCoursesHandler : IRequestHandler<GetAllCourses, IEnumerable<CourseViewModel>>
    {
        private readonly IReadRepository<Course> _courseRepository;
        private readonly IMemoryCache _memoryCache;

        public GetAllCoursesHandler(IReadRepository<Course> courseRepository,
              IMemoryCache memoryCache)
        {
            _courseRepository = courseRepository;
            _memoryCache = memoryCache;
        }
        public async Task<IEnumerable<CourseViewModel>> Handle(GetAllCourses request, CancellationToken cancellationToken)
        {
            return await _memoryCache.GetOrCreate("GetCourseList", async entity =>
            {
                var courses =await  _courseRepository.Include("Teacher").ToListAsync();
                return courses.Select(c => new CourseViewModel
                {
                    Id = c.Id,
                    CreatedTime = c.CreatedTime,
                    Price = c.Price,
                    Thumbnail = c.Thumbnail,
                    TitleEn = c.TitleEn,
                    TitleFa = c.TitleFa,
                    Teacher = c.Teacher.FullNameFa,
                    Duration = (int)(c.Duration / 3600) == 0 ? $"{(int)(c.Duration / 60)} دقیقه" : $"{(int)(c.Duration / 3600)} ساعت و {(int)((c.Duration % 3600) / 60)} دقیقه",
                    Level = c.Level.ToString()
                });
            });
        }
    }
}
