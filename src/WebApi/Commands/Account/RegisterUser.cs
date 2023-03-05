using MediatR;
using WebApi.ViewModels;
using WebApi.ViewModels.Acconut;

namespace WebApi.Commands.Account
{
    public class RegisterUser:IRequest<DefaultResultViewModel<string>>
    {
        public RegisterUser(RegisterViewModel register)
        {
            Register = register;
        }

        public RegisterViewModel Register { get; }
    }
}
