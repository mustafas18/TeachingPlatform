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
            var student = await Task.Run(()=> _studentRepository.Include("Courses").FirstOrDefault(s => s.UserName == request.StudentUserName));
            var course = await Task.Run(()=> _courseRepository.Include("Students").FirstOrDefault(s => s.Id == request.CourseId));
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
