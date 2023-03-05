using Core.Dtos;
using MediatR;
using WebApi.ViewModels.Acconut;

namespace WebApi.Commands.Account
{
    public class LoginUser:IRequest<LoginResultViewModel>
    {
        public LoginUser(LoginInfoDto userInfo)
        {
            UserInfo = userInfo;
        }

        public LoginInfoDto UserInfo { get; }
    }
}
