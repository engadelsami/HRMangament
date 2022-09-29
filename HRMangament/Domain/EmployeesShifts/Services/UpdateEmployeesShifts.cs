using HRMangament.Domain.EmployeesShiftses.AccessLayer;
using HRMangament.Domain.EmployeesShiftses.Commands;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.EmployeesShiftses.Services
{
    public interface IUpdateEmployeesShifts
    {
        void Excute(UpdateEmployeesShiftsCommand employeeShift);
    }
    public class UpdateEmployeesShifts:IUpdateEmployeesShifts
    {
        private readonly IEmployeesShiftsDataAdapter _employeesShiftsDataAdapter;

        public UpdateEmployeesShifts(IEmployeesShiftsDataAdapter employeesShiftsDataAdapter)
        {
            _employeesShiftsDataAdapter = employeesShiftsDataAdapter;
        }
        public void Excute(UpdateEmployeesShiftsCommand employeeShift)
        {
            //var oldEmployeesShift = new EmployeesShifts
            //{
            //    EmployeeId = employeeShift.EmployeeId,
            //    EmployeeShiftId = employeeShift.EmployeeShiftId,
            //    ShiftId = employeeShift.ShiftId,
       
            //};
            _employeesShiftsDataAdapter.UpdateEmployeesShift(employeeShift);
        }
    }
}
