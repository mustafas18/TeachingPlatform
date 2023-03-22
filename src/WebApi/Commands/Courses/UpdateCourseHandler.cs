﻿using Core.Entities;
using Core.Interfaces;
using MediatR;

namespace WebApi.Commands.Courses
{
    public class UpdateCourseHandler : IRequestHandler<CreateCourse, Course>
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IReadRepository<CourseCategory> _categoryReadRepo;
        private readonly IReadRepository<Teacher> _teacherReadRepo;

        public UpdateCourseHandler(IRepository<Course> courseRepository,
            IReadRepository<CourseCategory> categoryReadRepo,
             IReadRepository<Teacher> teacherReadRepo)
        {
            _courseRepository = courseRepository;
            _categoryReadRepo = categoryReadRepo;
            _teacherReadRepo = teacherReadRepo;
        }
        public async Task<Course> Handle(CreateCourse request, CancellationToken cancellationToken)
        {
            var category = _categoryReadRepo.GetByIdAsync(request.CourseCreate.CategoryId).Result;
            var teacher = _teacherReadRepo.GetByIdAsync(request.CourseCreate.TeacherId).Result;

            var course= _courseRepository.Where(p=>p.Id==request.CourseCreate.Id).FirstOrDefault();

            string thumbnail = string.Empty;
            if (request.CourseCreate.Thumbnail != null)
            {
                using var memoryStream = new MemoryStream();
                request.CourseCreate.Thumbnail.CopyToAsync(memoryStream);
                thumbnail = Convert.ToBase64String(memoryStream.ToArray());
            }
            else
            {
                thumbnail = course.Thumbnail;
            }


            course.Category = category;
            course.Description = request.CourseCreate.Description;
            course.Duration = request.CourseCreate.Duration;
            course.Price = request.CourseCreate.Price;
            course.Thumbnail = thumbnail;
            course.TitleEn = request.CourseCreate.TitleEn;
            course.TitleFa = request.CourseCreate.TitleFa;
            course.Teacher = teacher;

         await   _courseRepository.UpdateAsync(course);

            return course;
        }
    }
}