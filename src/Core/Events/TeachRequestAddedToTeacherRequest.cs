using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Events
{
    public class ItemAddedToTeacherRequest : EventBase
    {
        public TeacherRequest TeacherRequest;

        public ItemAddedToTeacherRequest(TeacherRequest teacherRequest)
        {
            TeacherRequest = teacherRequest;
        }
    }
}
