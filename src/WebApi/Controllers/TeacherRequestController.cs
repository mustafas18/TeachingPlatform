using Microsoft.AspNetCore.Mvc;
using MediatR;
using WebApi.ViewModels;
using WebApi.Commands.TeachingRequest;
using Infrastructure.Services;
using Core.Interfaces;
using Core.Entities;
using Core.Dtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TeacherRequestController: BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly ITeacherRequestService _teachRequestService;

        public TeacherRequestController(IMediator mediator, ITeacherRequestService teachRequestService )
        {
            _mediator = mediator;
            _teachRequestService = teachRequestService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllTeachingRequests());

            return Ok(result);
        }
        [HttpGet("{teacherId:int}")]
        public async Task<IActionResult> GetByTeacherId(int teacherId)
        {
            var result = await _mediator.Send(new GetTeachingRequests(teacherId));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TeacherRequestDto teacherRequest)
        {
            try
            {
                var result = _teachRequestService.AddTeacherRequest(teacherRequest);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            return Ok(new NotImplementedException());
        }
    }
}
