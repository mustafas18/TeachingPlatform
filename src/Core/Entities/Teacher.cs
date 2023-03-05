using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Teacher:BaseEntity, IAggregateRoot
    {
        public Teacher()
        {

        }
        public Teacher(string userName, string fullNameFa, string fullNameEn)
        {
            UserName = userName;
            FullNameFa = fullNameFa;
            FullNameEn = fullNameEn;
        }
        public string UserName { get; set; }
        public string FullNameFa { get; set; }
        public string FullNameEn { get; set; }
        [InverseProperty(nameof(Teacher))]
        public virtual ICollection<TeacherRequest> TeacherRequests { get; set; }
    }
}

