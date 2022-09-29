using HRMangament.Domain.EmployeesShiftses.AccessLayer;
using HRMangament.Domain.EmployeesShiftses.Commands;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.EmployeesShiftses.Services
{
    public interface IAddEmployeesShifts
    {
        void Excute(AddEmployeesShiftsCommand employeesShift);
    }
    public class AddEmployeesShifts: IAddEmployeesShifts
    {
        private readonly IEmployeesShiftsDataAdapter _employeesShiftsDataAdapter;

        public AddEmployeesShifts(IEmployeesShiftsDataAdapter employeesShiftsDataAdapter)
        {
            _employeesShiftsDataAdapter = employeesShiftsDataAdapter;
        }
        public void Excute(AddEmployeesShiftsCommand employeesShift)
        {
            EmployeesShifts newEmployeesShift = new EmployeesShifts()
            {
                EmployeeShiftId = employeesShift.EmployeeShiftId,
                EmployeeId = employeesShift.EmployeeId,
                ShiftId = employeesShift.ShiftId,
            };
            _employeesShiftsDataAdapter.AddEmployeesShift(newEmployeesShift);
        }
    }
}
