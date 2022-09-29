using HRMangament.Domain.Attendances.AccessLayer;
using HRMangament.Domain.Attendances.Commands;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Attendances.Services
{
    public interface IUpdateAttendance
    {
        void Excute(UpdateAttendanceCommand attendance);
    }
    public class UpdateAttendance : IUpdateAttendance
    {
        private readonly IAttendanceDataAdapter _attendanceDataAdapter;
        public UpdateAttendance(IAttendanceDataAdapter attendanceDataAdapter)
        {
            _attendanceDataAdapter = attendanceDataAdapter;
        }
        public void Excute(UpdateAttendanceCommand attendance)
        {
            //var oldAttendance = new Attendance
            //{
            //    EmployeeId = attendance.EmployeeId,
            //    AttendanceId = attendance.AttendanceId ,
            //    AttendanceTime = attendance.AttendanceTime,
            //    AttendanceType = attendance.AttendanceType,
                
            //};
            _attendanceDataAdapter.UpdateAttendance(attendance);
        }
    }
}
