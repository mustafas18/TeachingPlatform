using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Lesson : BaseEntity, IAggregateRoot
    {
        public Lesson(string nameFa, string nameEn, string description)
        {
            NameFa = nameFa;
            NameEn = nameEn;
            Description = description;
        }
        public string? NameFa { get; set; }
        public string? NameEn { get; set; }
        public string? Description { get; set; }

    }
}
