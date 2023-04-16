using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ConsultantSchedule: BaseEntity
    {
        public Teacher Consultant { get; set; }
        public string Mobile { get; set; }
        public string PayId { get; set; }
        public string Time { get; set; }
        public DateTime ReserveTime { get; set; }
    }
}
