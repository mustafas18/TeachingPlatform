using Core.Entities.CourseAggregate;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Student: BaseEntity, IAggregateRoot
    {
        public Student(string userName)
        {
            UserName = userName;
        }
        public string UserName { get; set; }
        [InverseProperty(nameof(Student))]
        public ICollection<TeacherRequest> TeacherRequests { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
