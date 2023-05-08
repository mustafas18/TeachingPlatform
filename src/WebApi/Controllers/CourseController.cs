using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using WebApi.Commands.Courses;
using WebApi.Commands.TeachingRequest;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CourseController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _env;

        public CourseController(IMediator mediator,
            IWebHostEnvironment env)
        {
            _mediator = mediator;
            _env = env;
        }
        [AllowAnonymous]
        [ResponseCache(Duration = 180, Location = ResponseCacheLocation.Any)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _mediator.Send(new GetAllCourses());

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorViewModel
                {
                    Message = ex.Message,
                    InnerMessage = ex.InnerException?.ToString(),
                    StackTrace = null
                });
            }

        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllWithoutCaching()
        {
            try
            {
                var result = await _mediator.Send(new GetAllCourses());

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorViewModel
                {
                    Message = ex.Message,
                    InnerMessage = ex.InnerException?.ToString(),
                    StackTrace = null
                });
            }

        }
        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(Duration = 180, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> GetByIdCached(int courseId)
        {
            try
            {
                var course = await _mediator.Send(new GetCourse(courseId));
                //course?.Sessions.ForEach(p => { p.Course = null; });
                return Ok(course);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorViewModel
                {
                    Message = ex.Message,
                    InnerMessage = ex.InnerException?.ToString(),
                    StackTrace = null
                });
            }

        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetById(int courseId)
        {
            try
            {
                var course = await _mediator.Send(new GetCourse(courseId));
                //course?.Sessions.ForEach(p => { p.Course = null; });
                return Ok(course);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorViewModel
                {
                    Message = ex.Message,
                    InnerMessage = ex.InnerException?.ToString(),
                    StackTrace = null
                });
            }

        }
        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(Duration = 180, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> GetSessionsByCourseId(int courseId)
        {
            try
            {
                var sessions = await _mediator.Send(new GetSessions(courseId));
                return Ok(sessions);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
#if DEBUG
        [AllowAnonymous]
#endif
        [Authorize(Roles = "admin,teacher")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CourseCreateViewModel course)
        {
            try
            {
                var result = await _mediator.Send(new CreateCourse(course));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorViewModel
                {
                    Message = ex.Message,
                    InnerMessage = ex.InnerException?.ToString(),
                    StackTrace = null
                });
            }

        }
        [Authorize(Roles = "admin,teacher")]
        [HttpPost]
        public async Task<IActionResult> UploadThumbnail([FromForm] IFormFile formFile)
        {
            try
            {
                var directory = Path.Combine(_env.ContentRootPath, "wwwroot",
                    "images", "courses");
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                var path = Path.Combine(directory, formFile.FileName);

                await using FileStream fileStream = new(path, FileMode.Create);
                await formFile.CopyToAsync(fileStream);
                var uri = new Uri($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/images/courses/{formFile.FileName}");

                return Ok(uri.AbsoluteUri);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorViewModel
                {
                    Message = ex.Message,
                    InnerMessage = ex.InnerException?.ToString(),
                    StackTrace = null
                });
            }

        }

        [Authorize(Roles = "admin,teacher")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CourseCreateViewModel course)
        {
            try
            {
                var result = await _mediator.Send(new UpdateCourse(course));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorViewModel
                {
                    Message = ex.Message,
                    InnerMessage = ex.InnerException?.ToString(),
                    StackTrace = null
                });
            }
        }
        [Authorize(Roles = "admin,teacher")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int courseId)
        {
            return Ok();
        }

    }
}
