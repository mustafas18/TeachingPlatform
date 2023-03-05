using Core.Dtos;
using Core.Entities.CourseAggregate;
using Core.Interfaces;
using Core.Specifications;
using MediatR;
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
            var specification = new CourseListSpecification();
            var courses = await _courseRepository.ListAsync(specification, cancellationToken);
            return courses.Select(c => new CourseViewModel
            {
                CreatedTime = c.CreatedTime,
                Price = c.Price,
                Thumbnail = c.Thumbnail,
                TitleEn = c.TitleEn,
                TitleFa = c.TitleFa,
            });
        }
    }
}
