using HRMangament.Domain.AccessLayer.Employees;
using HRMangament.Domain.Employees.Commands;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Services.Employees
{
    public interface IUpdateEmployee
    {
        void Excute(UpdateEmployeeCommand employee);
    }
    public class UpdateEmployee: IUpdateEmployee
    {
        private readonly IEmployeeDataAdapter _employeeDataAdapter;
        public UpdateEmployee(IEmployeeDataAdapter employeeDataAdapter )
        {
            _employeeDataAdapter = employeeDataAdapter;
        }
   
        public void Excute(UpdateEmployeeCommand employee)
        {
            //var oldEmployee = new Employee
            //{
            //    EmployeeId=employee.EmployeeId,
            //    EmployeeFirstName = employee.EmployeeFirstName,
            //    EmployeeLastName = employee.EmployeeLastName,
            //    EmployeeGender = employee.EmployeeGender,
            //    Salary = employee.Salary,
            //    VaccationNumber = employee.VaccationNumber,
            //    OrganizationId = employee.OrganizationId,
            //    EmployeeDOB = employee.EmployeeDOB,
            //    DateOfHire = employee.DateOfHire,
            //    FingerPrintId = employee.FingerPrintId
            //};
            _employeeDataAdapter.UpdateEmployee(employee);
        }
    }
}
