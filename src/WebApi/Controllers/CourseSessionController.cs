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
                return StatusCode(500, new ErrorViewModel
                {
                    Message = ex.Message,
                    InnerMessage = ex.InnerException.ToString(),
                    StackTrace = null
                });
            }
        }
#if DEBUG
        [AllowAnonymous]
#endif
        [Authorize(Roles = "admin,teacher")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SessionViewModel  session)
        {
            try
            {
                var result = await _mediator.Send(new CreateSession(session));
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ErrorViewModel
                {
                    Message = ex.Message,
                    InnerMessage = ex.InnerException.ToString(),
                    StackTrace = null
                });
            }
        }
        [Authorize(Roles = "admin,teacher")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Session session)
        {
            return Ok();
        }
        [Authorize(Roles = "admin,teacher")]
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
                return StatusCode(500, new ErrorViewModel
                {
                    Message = ex.Message,
                    InnerMessage = ex.InnerException.ToString(),
                    StackTrace = null
                });
            }
           
        }
    }
}
