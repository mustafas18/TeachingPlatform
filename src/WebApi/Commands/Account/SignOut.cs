using MediatR;

namespace WebApi.Commands.Account
{
    public class SignOut:IRequest<bool>
    {
        public SignOut()
        {

        }
    }
}
