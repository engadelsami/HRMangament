using HRMangament.Domain.EmployeesShiftses.AccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.EmployeesShiftses.Services
{
    public interface IDeleteEmployeesShifts
    {
        void Excute(int employeesShiftId);
    }
    public class DeleteEmployeesShifts: IDeleteEmployeesShifts
    {
        private readonly IEmployeesShiftsDataAdapter _employeesShiftsDataAdapter;

        public DeleteEmployeesShifts(IEmployeesShiftsDataAdapter employeesShiftsDataAdapter)
        {
            _employeesShiftsDataAdapter = employeesShiftsDataAdapter;
        }
        public void Excute(int employeesShiftId)
        {
            _employeesShiftsDataAdapter.DeleteEmployeesShift(employeesShiftId);
        }
    }
}
