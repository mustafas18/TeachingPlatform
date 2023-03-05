using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class EventAggregate:IAggregateRoot
    {
        public EventAggregate(string name, DateTime dateOccurred)
        {
            Name = name;
            DateOccurred = dateOccurred;
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOccurred { get; set; }
    }
}
