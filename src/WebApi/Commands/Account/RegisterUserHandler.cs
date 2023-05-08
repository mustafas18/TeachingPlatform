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
        private readonly IRepository<Student> _repository;

        public RegisterUserHandler(UserManager<AppUser> userManager,
            IMediator mediator,
            IRepository<Student> repository)
        {
            _userManager = userManager;
            _mediator = mediator;
            _repository = repository;
        }
        public async Task<AppUser> Handle(RegisterUser request, CancellationToken cancellationToken)
        {
            var result = _mediator.Send(new GetUser(request.Register.UserName));
            if (result.Result == null)
            {

                AppUser newUser = new AppUser();
                newUser.UserName = request.Register.UserName;
                newUser.Mobile = request.Register.Mobile;
                newUser.FullNameFa = request.Register.FullName;

                await _userManager.CreateAsync(newUser, request.Register.Password);
                await _userManager.AddToRoleAsync(newUser, "student");

                await _repository.AddAsync(new Student(newUser.UserName,newUser.Mobile, newUser.FullNameFa));

                return newUser;
            }
            return null;
        }
    }
}
