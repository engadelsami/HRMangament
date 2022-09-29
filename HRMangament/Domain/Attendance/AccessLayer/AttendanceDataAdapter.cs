using HRMangament.Domain.Attendances.Commands;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Attendances.AccessLayer
{
    public interface IAttendanceDataAdapter
    {
        List<Attendance> GetAttendances();
        void AddAttendance(Attendance attendance);
        void DeleteAttendance(int attendanceId);
        void UpdateAttendance(UpdateAttendanceCommand attendance);
        Attendance GetAttendanceById(int employeeId);
    }
    public class AttendanceDataAdapter : IAttendanceDataAdapter
    {
        private readonly HrContext _context;
        public AttendanceDataAdapter(HrContext context)
        {
            _context = context;
        }
        public void AddAttendance(Attendance attendance)
        {
            _context.Attendance.Add(attendance);
            _context.SaveChanges();
        }

        public void DeleteAttendance(int attendanceId)
        {
            var attendance = _context.Attendance.FirstOrDefault(e => e.AttendanceId == attendanceId);
            _context.Remove(attendance);
            _context.SaveChanges();
        }

        public void UpdateAttendance(UpdateAttendanceCommand _attendance)
        {
            var attendance = _context.Attendance.FirstOrDefault(e => e.AttendanceId == _attendance.AttendanceId);
            attendance.AttendanceTime = _attendance.AttendanceTime;
            attendance.AttendanceType = _attendance.AttendanceType;
            attendance.EmployeeId = _attendance.EmployeeId;

            _context.Update(attendance);
            _context.SaveChanges();
        }
        public Attendance GetAttendanceById(int attendanceId)
        {
            return _context.Attendance.FirstOrDefault(e => e.AttendanceId == attendanceId);
        }
        public List<Attendance> GetAttendances()
        {
            return _context.Attendance.ToList();
        }
    }
}
