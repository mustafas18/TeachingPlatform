﻿using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Net;
using System.Security.Claims;
using WebApi.Commands.Account;
using WebApi.ViewModels;
using WebApi.ViewModels.Acconut;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : BaseApiController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize(Roles = "admin,teacher")]
        [HttpGet]
        public async Task<IActionResult> GetUserInfo(string userName)
        {
            try
            {
                var result = await _mediator.Send(new GetUser(userName));
                return Ok(new UserInfoViewModel
                {
                    FullNameEn = result.FullNameEn,
                    FullNameFa = result.FullNameFa,
                    Mobile = result.Mobile,
                    Picture = result.Picture
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorViewModel
                {
                    Message = ex.Message,
                    InnerMessage = ex.InnerException?.ToString(),
                    StackTrace = null
                });
            }

        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel register)
        {
            try
            {
                var result = await _mediator.Send(new RegisterUser(register));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorViewModel
                {
                    Message = ex.Message,
                    InnerMessage = ex.InnerException?.ToString(),
                    StackTrace = null
                });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginInfoDto userInfo)
        {
            try
            {
                var result = await _mediator.Send(new LoginUser(userInfo));
                return Ok(result);
            }

            catch (Exception ex)
            {
                return StatusCode(500, new ErrorViewModel
                {
                    Message = ex.Message,
                    InnerMessage = ex.InnerException?.ToString(),
                    StackTrace = null
                });
            }
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            try
            {
                var result = await _mediator.Send(new SignOut());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorViewModel
                {
                    Message = ex.Message,
                    InnerMessage = ex.InnerException?.ToString(),
                    StackTrace = null
                });
            }
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetCurrentUser()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    var userClaims = identity.Claims;
                    return Ok(new CurrentUserViewModel
                    {
                        UserName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value,
                        Role = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
                    });
                }

                return Ok(new CurrentUserViewModel());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorViewModel
                {
                    Message = ex.Message,
                    InnerMessage = ex.InnerException?.ToString(),
                    StackTrace = null
                });
            }

        }

    }



}
