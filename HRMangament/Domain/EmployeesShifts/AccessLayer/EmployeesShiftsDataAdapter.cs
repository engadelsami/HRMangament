using HRMangament.Domain.EmployeesShiftses.Commands;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.EmployeesShiftses.AccessLayer
{
    public interface IEmployeesShiftsDataAdapter
    {
        List<EmployeesShifts> GetEmployeesShift();
        void AddEmployeesShift(EmployeesShifts employeesShift);
        void DeleteEmployeesShift(int employeesShiftId);
        void UpdateEmployeesShift(UpdateEmployeesShiftsCommand employeesShift);
        EmployeesShifts GetEmployeesShiftById(int employeesShiftId);
    }
    public class EmployeesShiftsDataAdapter: IEmployeesShiftsDataAdapter
    {
        private readonly HrContext _context;
        public EmployeesShiftsDataAdapter(HrContext context)
        {
            _context = context;
        }
        public void AddEmployeesShift(EmployeesShifts employeesShift)
        {
            _context.EmployeesShifts.Add(employeesShift);
            _context.SaveChanges();
        }

        public void DeleteEmployeesShift(int employeesShiftId)
        {
            var employeesShift = _context.EmployeesShifts.FirstOrDefault(e => e.EmployeeShiftId == employeesShiftId);
            _context.Remove(employeesShift);
            _context.SaveChanges();
        }

        public void UpdateEmployeesShift(UpdateEmployeesShiftsCommand _employeesShift)
        {
            var employeesShift = _context.EmployeesShifts.FirstOrDefault(e => e.EmployeeShiftId == _employeesShift.EmployeeShiftId);
            employeesShift.EmployeeId = _employeesShift.EmployeeId;
            employeesShift.ShiftId = _employeesShift.ShiftId;

            _context.Update(employeesShift);
            _context.SaveChanges();
        }
        public EmployeesShifts GetEmployeesShiftById(int employeesShiftId)
        {
            return _context.EmployeesShifts.FirstOrDefault(e => e.EmployeeShiftId == employeesShiftId);
        }
        public List<EmployeesShifts> GetEmployeesShift()
        {
            return _context.EmployeesShifts.ToList();
        }
    }
}
