using Core.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {

        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; protected set; }

        private List<EventBase> _events = new();
        public void AddEvent(EventBase @event) => _events.Add(@event);
        public void ClearEvents() => _events.Clear();
    }

}
