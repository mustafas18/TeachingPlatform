using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;

namespace WebApi.Commands.TeachingRequest
{
    public class GetTeachingRequests : IRequest<IEnumerable<TeachingRequestViewModel>>
    {
        public int TeacherId { get; set; }

        public GetTeachingRequests(int teacherId)
        {
            TeacherId= teacherId;
        }
    }
}
