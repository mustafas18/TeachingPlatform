using Core.Entities;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Commands.Courses
{
    public class GetCourseWithStudentHandler : IRequestHandler<GetCourseWithStudent, Course>
    {
        private readonly IReadRepository<Course> _courseRepository;

        public GetCourseWithStudentHandler(IReadRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<Course> Handle(GetCourseWithStudent request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository
                .Include("Students")
                .Include("Teacher")
                .FirstOrDefaultAsync(p => p.Id == request.CourseId);
            course.Thumbnail = "";
            course.Students.ForEach(p => p.Courses = null);
            return course;
        }
    }
}
