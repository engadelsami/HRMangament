using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Employees.Commands
{
    public class AddEmployeeCommand
    {
        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public DateTime EmployeeDOB { get; set; }
        public string EmployeeGender { get; set; }
        public DateTime DateOfHire { get; set; }
        public decimal Salary { get; set; }
        public byte IsActive { get; set; }
        public int OrganizationId { get; set; }
        public int VaccationNumber { get; set; }
        public int FingerPrintId { get; set; }
    }
}
