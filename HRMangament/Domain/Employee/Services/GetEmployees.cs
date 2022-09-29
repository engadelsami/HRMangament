using HRMangament.Domain.AccessLayer.Employees;
using HRMangament.Domain.Employees.Commands;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Services.Employees
{
    public interface IGetEmployees
    {
        List<GetEmployeeCommand> Excute();
    }
    public class GetEmployees : IGetEmployees
    {
        private readonly IEmployeeDataAdapter _employeeDataAdapter;

        public GetEmployees(IEmployeeDataAdapter employeeDataAdapter)
        {
            _employeeDataAdapter = employeeDataAdapter;
        }
        public List<GetEmployeeCommand> Excute()
        {
            var Employees = new List<GetEmployeeCommand>();

            foreach (var item in _employeeDataAdapter.GetEmployees())
            {
                var model = new GetEmployeeCommand();

                model.EmployeeId = item.EmployeeId;
                model.EmployeeFirstName = item.EmployeeFirstName;
                model.EmployeeLastName = item.EmployeeLastName;
                model.EmployeeGender = item.EmployeeGender;
                model.Salary = item.Salary;
                model.VaccationNumber = item.VaccationNumber;
                model.OrganizationId = item.OrganizationId;
                model.EmployeeDOB = item.EmployeeDOB;
                model.DateOfHire = item.DateOfHire;
                
                Employees.Add(model);
            }
            return Employees;

        }
    }
}
