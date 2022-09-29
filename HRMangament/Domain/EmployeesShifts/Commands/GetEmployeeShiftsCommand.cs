using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.EmployeesShiftses.Commands
{
    public class GetEmployeeShiftsCommand
    {
        public int EmployeeShiftId { get; set; }
        public int EmployeeId { get; set; }
        public int ShiftId { get; set; }
    }
}
