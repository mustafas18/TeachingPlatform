using Core.Entities;
using MediatR;
using WebApi.ViewModels;
using WebApi.ViewModels.Acconut;

namespace WebApi.Commands.Account
{
    public class RegisterUser:IRequest<AppUser>
    {
        public RegisterUser(RegisterViewModel register)
        {
            Register = register;
        }

        public RegisterViewModel Register { get; }
    }
}
