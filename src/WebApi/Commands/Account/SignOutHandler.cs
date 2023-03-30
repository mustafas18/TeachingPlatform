using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace WebApi.Commands.Account
{
    public class SignOutHandler : IRequestHandler<SignOut, bool>
    {
        private readonly SignInManager<AppUser> _signInManager;

        public SignOutHandler(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public Task<bool> Handle(SignOut request, CancellationToken cancellationToken)
        {
           _signInManager.SignOutAsync();
            return Task.FromResult(true);
        }
    }
}
