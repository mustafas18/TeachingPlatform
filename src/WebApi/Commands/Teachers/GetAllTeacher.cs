using Core.Entities;
using MediatR;
using WebApi.ViewModels;
namespace WebApi.Commands.Teachers
{
    public class GetAllTeacher : IRequest<List<Teacher>>
    {
        public GetAllTeacher()
        {
                
        }
    }
}
