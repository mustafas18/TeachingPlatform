﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Commands.Courses;
using WebApi.Commands.TeachingRequest;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CourseController: BaseApiController
    {
        private readonly IMediator _mediator;
        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var result = await _mediator.Send(new GetAllCourses());

            return Ok(result);
        }

    }
}
