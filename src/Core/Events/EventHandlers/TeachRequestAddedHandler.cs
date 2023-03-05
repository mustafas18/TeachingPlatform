using Core.Entities;
using Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Events.EventHandlers
{
    public class TeachRequestAddedHandler : INotificationHandler<ItemAddedToTeacherRequest>
    {
        private readonly IRepository<EventAggregate> _eventRepository;

        public async Task Handle(ItemAddedToTeacherRequest notification, CancellationToken cancellationToken)
        {
          await  _eventRepository.AddAsync(new EventAggregate(nameof(notification.TeacherRequest), notification.DateOccurred));
        }
    }
}
