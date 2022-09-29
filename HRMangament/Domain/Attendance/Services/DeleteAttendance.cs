using HRMangament.Domain.Attendances.AccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Attendances.Services
{
    public interface IDeleteAttendance
    {
        void Excute(int attendanceId);
    }
    public class DeleteAttendance : IDeleteAttendance
    {
        private readonly IAttendanceDataAdapter _attendanceDataAdapter;

        public DeleteAttendance(IAttendanceDataAdapter attendanceDataAdapter)
        {
            _attendanceDataAdapter = attendanceDataAdapter;
        }
        public void Excute(int attendanceId)
        {
            _attendanceDataAdapter.DeleteAttendance(attendanceId);
        }
    }
}
