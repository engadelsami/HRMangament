using HRMangament.Domain.Attendances.AccessLayer;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Attendances.Services
{
    public interface IGetAttendanceById
    {
        Attendance Excute(int attendanceId);
    }
    public class GetAttendanceById : IGetAttendanceById
    {
        private readonly IAttendanceDataAdapter _attendanceDataAdapter;

        public GetAttendanceById(IAttendanceDataAdapter attendanceDataAdapter)
        {
            _attendanceDataAdapter = attendanceDataAdapter;
        }
        public Attendance Excute(int attendanceId)
        {
            return _attendanceDataAdapter.GetAttendanceById(attendanceId);
        }
    }
}
