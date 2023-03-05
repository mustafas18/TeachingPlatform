using Core.Entities.CourseAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Student: BaseEntity
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
