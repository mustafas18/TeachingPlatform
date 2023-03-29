using Core.Entities;
using Core.Interfaces;
using MediatR;

namespace WebApi.Commands.Account
{
    public class IsCourseStudentHandler : IRequestHandler<IsCourseStudent, bool>
    {
        private readonly IReadRepository<Course> _courseRepository;
        private readonly IReadRepository<Student> _studentRepository;

        public IsCourseStudentHandler(IReadRepository<Course> courseRepository,
            IReadRepository<Student> studentRepository)
        {
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
        }
        public async Task<bool> Handle(IsCourseStudent request, CancellationToken cancellationToken)
        {
            var courseId = request.CourseStudent.CourseId;
            var course= _courseRepository
                  .Include("Student").FirstOrDefault(s => s.Id== courseId);
            var student = _studentRepository
                .Include("Courses")
                .FirstOrDefault(p => p.UserName == request.CourseStudent.UserName);
                return course.Students.Contains(student);
        }
    }
}
