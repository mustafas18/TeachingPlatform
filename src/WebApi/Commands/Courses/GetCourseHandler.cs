using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using MediatR;
using WebApi.ViewModels;

namespace WebApi.Commands.Courses
{
    public class GetCourseHandler : IRequestHandler<GetCourse, Course>
    {
        private readonly IReadRepository<Course> _courseRepository;

        public GetCourseHandler(IReadRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<Course> Handle(GetCourse request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.CourseWithSession(request.CourseId);
            return course;
        }
    }
}
