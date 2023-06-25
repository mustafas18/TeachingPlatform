using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WebApi.ViewModels;

namespace WebApi.Commands.Courses
{
    public class GetCourseHandler : IRequestHandler<GetCourse, Course>
    {
        private readonly IReadRepository<Course> _courseRepository;
        private readonly IMemoryCache _memoryCache;

        public GetCourseHandler(IReadRepository<Course> courseRepository,
            IMemoryCache memoryCache)
        {
            _courseRepository = courseRepository;
            _memoryCache = memoryCache;
        }
        public async Task<Course> Handle(GetCourse request, CancellationToken cancellationToken)
        {
            var course =await Task.Run(()=> _courseRepository
                       .Include("Sessions,Teacher")
                       .FirstOrDefault(p => p.Id == request.CourseId));
            if (course.Sessions != null)
            {
                course.Sessions = course.Sessions.OrderBy(s => s.OrderNumber).ToList();
            }
 
            return course;
        }
    }
}
