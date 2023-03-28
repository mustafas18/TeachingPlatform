using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Commands.Account
{
    public class SignUpCourseHandler : IRequestHandler<SignUpCourse, Course>
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Course> _courseRepository;

        public SignUpCourseHandler(IRepository<Student> studentRepository,
           IRepository<Course> courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }
        public async Task<Course> Handle(SignUpCourse request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.Include("Courses").FirstOrDefaultAsync(s => s.UserName == request.StudentUserName);
            var course = await _courseRepository.Include("Students").FirstOrDefaultAsync(s => s.Id == request.CourseId);
            var existsInCourse = course.Students.FirstOrDefault(s => s.UserName == student.UserName);
            if (existsInCourse == null)
            {
                course.Students.Add(student);
                student.Courses.Add(course);
                await _studentRepository.UpdateAsync(student);
                await _courseRepository.UpdateAsync(course);
            }

            return course;


        }
    }
}
