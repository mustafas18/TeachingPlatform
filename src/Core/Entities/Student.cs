using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Student: BaseEntity, IAggregateRoot
    {
        public Student()
        {

        }
        public Student(string userName)
        {
            UserName = userName;
        }
        public string UserName { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
