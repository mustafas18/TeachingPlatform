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
        public Student(string userName,string mobile, string fullNameFa)
        {
            UserName = userName;
            Mobile = mobile;
            FullNameFa = fullNameFa;
        }
        public string UserName { get; set; }
        public string FullNameFa { get; set; }
        public string Mobile { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
