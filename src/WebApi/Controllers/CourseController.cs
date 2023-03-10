using Core.Entities;
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
            try
            {
                var result = await _mediator.Send(new GetAllCourses());

                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetById(int courseId)
        {
            try
            {
                var course = await _mediator.Send(new GetCourse(courseId));
                course.Sessions.ForEach(p => { p.Course = null; });
                return Ok(course);
            }
            catch(Exception ex)
            {
               return StatusCode(500, ex.Message);
            }

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
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Course course)
        {
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int courseId)
        {
            return Ok();
        }

    }
}
