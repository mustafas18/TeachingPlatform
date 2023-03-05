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
        public BaseEntity(int id)
        {
            Id = id;
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        private List<EventBase> _events = new();
        public void AddEvent(EventBase @event) => _events.Add(@event);
        public void ClearEvents() => _events.Clear();
    }

}
