﻿using Microsoft.AspNetCore.Mvc;
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
    public class TeacherRequestController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly ITeacherRequestService _teachRequestService;

        public TeacherRequestController(IMediator mediator, ITeacherRequestService teachRequestService)
        {
            _mediator = mediator;
            _teachRequestService = teachRequestService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _mediator.Send(new GetAllTeachingRequests());

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TeachingRequestViewModel teacherRequest)
        {
            try
            {
                var result = await _mediator.Send(new CreateTeachingRequest(teacherRequest));
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

        [HttpDelete]
        public async Task<IActionResult> Delete(int requestId)
        {
            return Ok();
        }
    }
}
