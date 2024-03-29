﻿using Core.Entities;
using Core.Enums;

namespace WebApi.ViewModels
{
    public class CourseCreateViewModel
    {
        public int Id { get; set; }
        public string TitleFa { get; set; }
        public string TitleEn { get; set; }
        public int CategoryId { get; set; }
        public int TeacherId { get; set; }
        public string? TeacherName { get; set; }
        public string? Description { get; set; }
        public List<Session> Sessions { get; set; }
        public int Price { get; set; }
        /// <summary>
        /// Duriation in second
        /// </summary>
        public int Duration { get; set; }
        public CourseLevel Level { get; set; }
        public string? FileName { get; set; }
        public string? ThumbnailUri { get; set; }
        public string ThumbnailBase46 { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
