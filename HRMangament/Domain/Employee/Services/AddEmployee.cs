using HRMangament.Domain.AccessLayer.Employees;
using HRMangament.Domain.Employees.Commands;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Services.Employees
{
    public interface IAddEmployee
    {
        void Excute(AddEmployeeCommand employee);
    }
    public class AddEmployee: IAddEmployee
    {
        private readonly IEmployeeDataAdapter _employeeDataAdapter;

        public AddEmployee(IEmployeeDataAdapter employeeDataAdapter)
        {
            _employeeDataAdapter = employeeDataAdapter;
        }
        public void Excute(AddEmployeeCommand employee)
        {
            Employee newEmployee = new Employee()
            {
                EmployeeFirstName = employee.EmployeeFirstName,
                EmployeeLastName = employee.EmployeeLastName,
                EmployeeGender = employee.EmployeeGender,
                Salary = employee.Salary,
                VaccationNumber = employee.VaccationNumber,
                OrganizationId = employee.OrganizationId,
                EmployeeDOB = employee.EmployeeDOB,
                DateOfHire = employee.DateOfHire
            };
            _employeeDataAdapter.AddEmployee(newEmployee);
        }
    }
}
