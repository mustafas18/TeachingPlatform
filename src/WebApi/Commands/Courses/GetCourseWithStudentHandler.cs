using Core.Entities;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Commands.Courses
{
    public class GetCourseWithStudentHandler : IRequestHandler<GetCourseWithStudent, Course>
    {
        private readonly ICourseRepository _courseRepository;

        public GetCourseWithStudentHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<Course> Handle(GetCourseWithStudent request, CancellationToken cancellationToken)
        {
            var course = await Task.Run(()=> _courseRepository
                .CourseWithTeachersAndStudent()
                .FirstOrDefault(p => p.Id == request.CourseId));
            course.Thumbnail = "";
            course.Students.ForEach(p => p.Courses = null);
            return course;
        }
    }
}
