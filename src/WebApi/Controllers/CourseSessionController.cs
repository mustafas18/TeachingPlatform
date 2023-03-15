using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Commands.Courses;
using WebApi.Commands.CourseSessions;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CourseSessionController : BaseApiController
    {
        private readonly IMediator _mediator;
        public CourseSessionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetbySessionId(int sessionId)
        {
            try
            {
                var result = await _mediator.Send(new GetSession(sessionId));

                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
#if DEBUG
        [AllowAnonymous]
#endif
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SessionViewModel session)
        {
            try
            {
                var result = await _mediator.Send(new CreateSession(session));
                return Ok(result);
            }
            catch(Exception ex)
            {
               return StatusCode(500,ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Session session)
        {
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int sessionId)
        {
            try
            {
                var result = await _mediator.Send(new DeleteSession(sessionId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
           
        }
    }
}
