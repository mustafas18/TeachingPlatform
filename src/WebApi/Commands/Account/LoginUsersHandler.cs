using Core.Interfaces;
using MediatR;
using WebApi.ViewModels.Acconut;

namespace WebApi.Commands.Account
{
    public class LoginUsersHandler : IRequestHandler<LoginUser, LoginResultViewModel>
    {
        private readonly ITokenClaimsService _token;

        public LoginUsersHandler(ITokenClaimsService token)
        {
            _token = token;
        }

        public async Task<LoginResultViewModel> Handle(LoginUser request, CancellationToken cancellationToken)
        {
            var accessToken = await _token.GetTokenAsync(request.UserInfo);

            return new LoginResultViewModel
            {
                UserName = request.UserInfo?.UserName,
                AccessToken = accessToken,
                IssuedDate = DateTime.UtcNow,
            };
        }
    }
}
