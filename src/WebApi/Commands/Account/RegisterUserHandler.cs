using Core.Entities;
using Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using WebApi.ViewModels;

namespace WebApi.Commands.Account
{
    public class RegisterUserHandler : IRequestHandler<RegisterUser, AppUser>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMediator _mediator;

        public RegisterUserHandler(UserManager<AppUser> userManager,
            IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;
        }
        public async Task<AppUser> Handle(RegisterUser request, CancellationToken cancellationToken)
        {
            var result = _mediator.Send(new GetUser(request.Register.UserName));
            if (result == null)
            {

                AppUser newUser = new AppUser();
                newUser.UserName = request.Register.UserName;

                await _userManager.CreateAsync(newUser, request.Register.Password);
                await _userManager.AddToRoleAsync(newUser, "student");

                return newUser;
            }
            return null;
        }
    }
}
