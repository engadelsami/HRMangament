using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Attendances.Commands
{
    public class GetAttendanceCommand
    {
        public int AttendanceId { get; set; }
        public DateTime AttendanceTime { get; set; }
        public string AttendanceType { get; set; }
        public int EmployeeId { get; set; }
    }
}
