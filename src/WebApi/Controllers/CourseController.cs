using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Commands.Courses;
using WebApi.Commands.TeachingRequest;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CourseController : BaseApiController
    {
        private readonly IMediator _mediator;
        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllCourses());

            return Ok(result);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetById(int courseId)
        {
            var result = await _mediator.Send(new GetCourse(courseId));

            return Ok(result);
        }
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
                return StatusCode(500, ex.Message);
            }

        }

    }
}
