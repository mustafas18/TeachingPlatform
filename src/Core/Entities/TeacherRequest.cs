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
        public TeacherRequest(Student student,  Lesson lesson, OrderStatus status)
        {
            Student = student;
            Lesson = lesson;
            Status = status;
        }
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
        public TeachType Type { get; set; }
        public string Place { get; set; }
        public Lesson Lesson { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public string RequestGuid { get; set; }
        public DateTime RequestTime { get; set; }
    public OrderStatus Status { get; set; }
    }
}
