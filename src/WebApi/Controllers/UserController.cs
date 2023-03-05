using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;
using WebApi.Commands.Account;
using WebApi.ViewModels.Acconut;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel register)
        {
            var result =await _mediator.Send(new RegisterUser(register));
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginInfoDto userInfo)
        {
            try
            {
                var result = await _mediator.Send(new LoginUser(userInfo));
                return Ok(result);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
           
              


    }
}