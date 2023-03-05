using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public interface TeacherRequestDto
    {
        public int TeacherId { get; set; }
        public string StudentUserId { get; set; }
        public int LessonId { get; set; }
        public TeachType TeachingType { get; set; }
    }
}
