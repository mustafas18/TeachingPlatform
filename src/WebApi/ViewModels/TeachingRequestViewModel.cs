﻿using Core.Entities;
using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels
{
    public class TeachingRequestViewModel
    {
        public Student Student { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string LessonEnName { get; set; }
        public TeachType Type { get; set; }
        public string Place { get; set; }
        public int Price { get; set; }
        public DateTime RequestDateTime { get; set; }
        public string? Description { get; set; }
        public string? RequestGuid { get; set; }
        public OrderStatus Status { get; set; }
    }
}
