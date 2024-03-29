﻿using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using MediatR;

namespace WebApi.Commands.CourseSessions
{
    public class CreateSessionHandler : IRequestHandler<CreateSession, Session>
    {
        private readonly IReadRepository<Course> _courseReadRepository;
        private readonly IRepository<Course> _courseRepo;
        private readonly IRepository<Session> _sessRepo;

        public CreateSessionHandler(IReadRepository<Course> courseReadRepository,
            IRepository<Course> courseRepo,
            IRepository<Session> sessRepo)
        {
            _courseReadRepository = courseReadRepository;
            _courseRepo = courseRepo;
            _sessRepo= sessRepo;
        }
        public async Task<Session> Handle(CreateSession request, CancellationToken cancellationToken)
        {

            var session = new Session
            {
                Description = request.Session.Description,
                SessionType = request.Session.SessionType,
                Thumbnail = request.Session.Thumbnail,
                TitleEn = request.Session.TitleEn,
                TitleFa = request.Session.TitleFa,
                Duration = request.Session.Duration,
                OrderNumber = request.Session.OrderNumber,
                ResourseType = request.Session.ResourseType,
                ResourceUri = request.Session.ResourceUri,
                 Status=request.Session.Status
            };

            var course = _courseRepo
                .Include("Sessions")
                .FirstOrDefault(p => p.Id == request.Session.CourseId);
            course.Sessions.Add(session);
           await _courseRepo.UpdateAsync(course);
            session.Id = course.Sessions.OrderBy(p=>p.Id).LastOrDefault().Id;
            return session;
        }
    }
}
