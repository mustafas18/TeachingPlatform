using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Commands.Courses;
using WebApi.Commands.Teachers;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TeacherController : BaseApiController
    {
        private readonly IMediator _mediator;
        public TeacherController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _mediator.Send(new GetAllTeacher());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> Create([FromBody] Teacher course)
        {
            return StatusCode(501, "Not Implemented");
        }
        [Authorize(Roles = "admin,teacher")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Course course)
        {
            return StatusCode(501, "Not Implemented");
        }
        [Authorize(Roles = "admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int teacherId)
        {
            return StatusCode(501, "Not Implemented");
        }

    }
}
