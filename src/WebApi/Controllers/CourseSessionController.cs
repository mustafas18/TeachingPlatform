﻿using MediatR;
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
        [HttpGet]
        public async Task<IActionResult> Get(int courseId)
        {
            var result = await _mediator.Send(new GetSessions(courseId));

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SessionViewModel session)
        {
            var result = await _mediator.Send(new CreateSession(session));
            return Ok(result);
        }

    }
}
