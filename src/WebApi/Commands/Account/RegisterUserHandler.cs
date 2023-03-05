using MediatR;
using WebApi.ViewModels;

namespace WebApi.Commands.Account
{
    public class RegisterUserHandler : IRequestHandler<RegisterUser, DefaultResultViewModel<string>>
    {
        public RegisterUserHandler()
        {

        }
        public Task<DefaultResultViewModel<string>> Handle(RegisterUser request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
