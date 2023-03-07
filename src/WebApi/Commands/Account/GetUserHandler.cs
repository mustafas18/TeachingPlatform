using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using MediatR;

namespace WebApi.Commands.Account
{
    public class GetUserHandler : IRequestHandler<GetUser, AppUser>
    {
        private readonly IReadRepository<AppUser> _userRepository;

        public GetUserHandler(IReadRepository<AppUser> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<AppUser> Handle(GetUser request, CancellationToken cancellationToken)
        {
            var spec = new UserByUserIdSpecification(request.UserName);
           var result=await _userRepository.GetBySpecAsync(spec, cancellationToken);
            return result;
        }
    }
}
