using Microsoft.AspNetCore.Mvc;
using MediatR;
using WebApi.ViewModels;
using WebApi.Commands.TeachingRequest;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TeacherRequestController: BaseApiController
    {
        private readonly IMediator _mediator;
        public TeacherRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllTeachingRequests());

            return Ok(result);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByTeacherId(int teacherId)
        {
            var result = await _mediator.Send(new GetTeachingRequests(teacherId));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TeacherRequestViewModel teacherRequest)
        {
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int teacherRequestId)
        {
            return Ok();
        }
    }
}
