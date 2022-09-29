using HRMangament.Domain.EmployeesShiftses.Commands;
using HRMangament.Domain.EmployeesShiftses.AccessLayer;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.EmployeesShiftses.Services
{
    public interface IGetEmployeesShifts
    {
        List<GetEmployeeShiftsCommand> Excute();
    }
    public class GetEmployeesShifts: IGetEmployeesShifts
    {
        private readonly IEmployeesShiftsDataAdapter _employeesShiftsDataAdapter;

        public GetEmployeesShifts(IEmployeesShiftsDataAdapter employeesShiftsDataAdapter)
        {
            _employeesShiftsDataAdapter = employeesShiftsDataAdapter;
        }
        public List<GetEmployeeShiftsCommand> Excute()
        {
            var EmployeesShift = new List<GetEmployeeShiftsCommand>();

            foreach (var item in _employeesShiftsDataAdapter.GetEmployeesShift())
            {
                var model = new GetEmployeeShiftsCommand();

                model.EmployeeId = item.EmployeeId;
                model.ShiftId = item.ShiftId;
                model.EmployeeShiftId = item.EmployeeShiftId;


                EmployeesShift.Add(model);
            }
            return EmployeesShift;

        }
    }
}
