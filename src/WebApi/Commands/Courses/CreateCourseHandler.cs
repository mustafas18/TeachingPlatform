﻿using Core.Entities;
using Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using WebApi.ViewModels;

namespace WebApi.Commands.Courses
{
    public class CreateCourseHandler : IRequestHandler<CreateCourse, Course>
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IReadRepository<CourseCategory> _categoryReadRepo;
        private readonly IReadRepository<Teacher> _teacherReadRepo;
        private readonly IMemoryCache _memoryCache;

        public CreateCourseHandler(IRepository<Course> courseRepository,
            IReadRepository<CourseCategory> categoryReadRepo,
             IReadRepository<Teacher> teacherReadRepo,
             IMemoryCache memoryCache)
        {
            _courseRepository = courseRepository;
            _categoryReadRepo = categoryReadRepo;
            _teacherReadRepo = teacherReadRepo;
            _memoryCache = memoryCache;
        }
        public async Task<Course> Handle(CreateCourse request, CancellationToken cancellationToken)
        {
            var category = _categoryReadRepo.GetByIdAsync(request.CourseCreate.CategoryId).Result;
            var teacher = _teacherReadRepo.GetByIdAsync(request.CourseCreate.TeacherId).Result;

            // Save thumbnails as file
            //var fileExtension = System.IO.Path.GetExtension(request.CourseCreate.FormFile.FileName)?.ToLower().Replace(".","");
            //var fileName = $"Course_{Guid.NewGuid()}{fileExtension}";
            //string filePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads", fileName);

            //if (!Directory.Exists(filePath))
            //    Directory.CreateDirectory(filePath);
            //filePath += fileExtension;
            //using var stream = new FileStream(filePath, FileMode.CreateNew);
            //request.CourseCreate.FormFile.CopyToAsync(stream, cancellationToken);
            //var thumbnail = fileName;

            //Save thumbnails as base64


            var course = new Course
            {
                Category = category,
                CreatedTime = DateTime.UtcNow,
                Description = request.CourseCreate.Description,
                Duration = request.CourseCreate.Duration,
                 Level= request.CourseCreate.Level,
                Price = request.CourseCreate.Price,
                Thumbnail = request.CourseCreate.ThumbnailBase46,
                TitleEn = request.CourseCreate.TitleEn,
                TitleFa = request.CourseCreate.TitleFa,
                Teacher = teacher,
               // Sessions=request.CourseCreate.Sessions
            };
            _courseRepository.AddAsync(course);
            _memoryCache.Remove("GetCourseList");
            return course;
        }
    }
}
