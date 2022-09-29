using HRMangament.Domain.Attendances.Commands;
using HRMangament.Domain.Attendances.AccessLayer;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Attendances.Services
{
    public interface IGetAttendance
    {
        List<GetAttendanceCommand> Excute();
    }
    public class GetAttendances:IGetAttendance
    {
        public readonly IAttendanceDataAdapter _attendanceDataAdapter;
        public GetAttendances(IAttendanceDataAdapter attendanceDataAdapter)
        {
            _attendanceDataAdapter = attendanceDataAdapter;
        }
        public List<GetAttendanceCommand> Excute()
        {
            var Attendances = new List<GetAttendanceCommand>();

            foreach (var item in _attendanceDataAdapter.GetAttendances())
            {
                var model = new GetAttendanceCommand();

                model.EmployeeId = item.EmployeeId;
                model.AttendanceId = item.AttendanceId;
                model.AttendanceTime = item.AttendanceTime;
                model.AttendanceType = item.AttendanceType;

                Attendances.Add(model);
            }
            return Attendances;

        }
    }
}
