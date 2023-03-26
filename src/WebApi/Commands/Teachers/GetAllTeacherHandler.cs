using Core.Entities;
using Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using WebApi.Commands.Courses;

namespace WebApi.Commands.Teachers
{
    public class GetAllTeacherHandler : IRequestHandler<GetAllTeacher, List<Teacher>>
    {
        private readonly IReadRepository<Teacher> _readRepository;

        public GetAllTeacherHandler(IReadRepository<Teacher> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<List<Teacher>> Handle(GetAllTeacher request, CancellationToken cancellationToken)
        {
            return await _readRepository.GetAllAsync();
        }
    }
}
