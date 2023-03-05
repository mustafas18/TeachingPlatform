using Core.Entities;
using Core.Events;
using Core.Interfaces;
using Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{

    public class TeacherRequestService
    {
        private readonly IRepository<TeacherRequest> _teacherRequestRepository;
        public TeacherRequestService(IRepository<TeacherRequest> TeacherRequestRepository)
        {
            _teacherRequestRepository = TeacherRequestRepository;
        }

        public async Task AddTeacherRequest(TeacherRequest teacherRequest)
        {
            await _teacherRequestRepository.AddAsync(teacherRequest);

            var ItemAddedToTeacherRequest = new ItemAddedToTeacherRequest(teacherRequest);
            teacherRequest.AddEvent(ItemAddedToTeacherRequest);
        }
    }
}
