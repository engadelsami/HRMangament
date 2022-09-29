using HRMangament.Domain.EmployeesShiftses.AccessLayer;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.EmployeesShiftses.Services
{
    public interface IGetEmployeesShiftById
    {
        EmployeesShifts Excute(int employeesShiftId);
    }
    public class GetEmployeesShiftsById : IGetEmployeesShiftById
    {
        private readonly IEmployeesShiftsDataAdapter _employeesShiftsDataAdapter;

        public GetEmployeesShiftsById(IEmployeesShiftsDataAdapter employeesShiftsDataAdapter)
        {
            _employeesShiftsDataAdapter = employeesShiftsDataAdapter;
        }
        public EmployeesShifts Excute(int employeesShiftId)
        {
            return _employeesShiftsDataAdapter.GetEmployeesShiftById(employeesShiftId);
        }
    }
}
