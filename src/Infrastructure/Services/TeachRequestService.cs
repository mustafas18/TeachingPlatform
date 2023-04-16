using Core.Dtos;
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

    public class TeacherRequestService : ITeacherRequestService
    {
        private readonly IRepository<TeacherRequest> _teacherRequestRepository;
        private readonly IReadRepository<Student> _studentReadRepository;
        private readonly IReadRepository<Teacher> _teacherReadRepository;
        private readonly IReadRepository<Lesson> _lessonReadRepository;

        public TeacherRequestService(IRepository<TeacherRequest> TeacherRequestRepository,
            IReadRepository<Student> studentReadRepository,
             IReadRepository<Teacher> teacherReadRepository,
           IReadRepository<Lesson> lessonReadRepository)
        {
            _teacherRequestRepository = TeacherRequestRepository;
            _studentReadRepository = studentReadRepository;
            _teacherReadRepository = teacherReadRepository;
            _lessonReadRepository = lessonReadRepository;
        }

        public async Task<TeacherRequest> AddTeacherRequest(TeacherRequestDto teacherRequest)
        {
            var teachRequest = new TeacherRequest
            {
                Lesson = _lessonReadRepository.GetByIdAsync(teacherRequest.LessonId).Result,
                Student = _studentReadRepository.GetByIdAsync(teacherRequest.StudentUserId).Result,
                 Type= teacherRequest.TeachingType,
                Status = Core.Enums.OrderStatus.Pending
            };
            await _teacherRequestRepository.AddAsync(teachRequest);

            var ItemAddedToTeacherRequest = new ItemAddedToTeacherRequest(teachRequest);
            teachRequest.AddEvent(ItemAddedToTeacherRequest);

            return teachRequest;
        }
    }
}
