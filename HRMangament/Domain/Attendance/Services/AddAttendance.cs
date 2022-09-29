using HRMangament.Domain.Attendances.AccessLayer;
using HRMangament.Domain.Attendances.Commands;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Attendances.Services
{
    public interface IAddAttendance
    {
        void Excute(AddAttendanceCommand attendance);
    }
    public class AddAttendance : IAddAttendance
    {
        private readonly IAttendanceDataAdapter _attendanceDataAdapter;
        public AddAttendance(IAttendanceDataAdapter attendanceDataAdapter)
        {
            _attendanceDataAdapter = attendanceDataAdapter;
        }

        public void Excute(AddAttendanceCommand attendance)
        {
            Attendance newAttendance = new Attendance()
            {
                //AttendanceId = attendance.AttendanceId,
                AttendanceTime = attendance.AttendanceTime,
                AttendanceType = attendance.AttendanceType,
                EmployeeId = attendance.EmployeeId
            };
            _attendanceDataAdapter.AddAttendance(newAttendance);
        }
    }
}
