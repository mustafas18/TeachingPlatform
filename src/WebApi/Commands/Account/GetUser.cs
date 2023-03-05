using Core.Entities;
using MediatR;

namespace WebApi.Commands.Account
{
    public class GetUser:IRequest<AppUser>
    {
        public GetUser(string UserName)
        {
            this.UserName = UserName;
        }

        public string UserName { get; }
    }
}
