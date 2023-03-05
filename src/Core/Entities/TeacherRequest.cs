using Core.Enums;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class TeacherRequest : BaseEntity, IAggregateRoot
    {
        public TeacherRequest() 
        {

        }
        public TeacherRequest(Student student, Teacher teacher, TeachType type, Lesson lesson, OrderStatus status)
        {
            Student = student;
            Teacher = teacher;
            Type = type;
            Lesson = lesson;
            Status = status;
        }
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
        public TeachType Type { get; set; }
        public Lesson Lesson { get; set; }
        public OrderStatus Status { get; set; }
    }
}
