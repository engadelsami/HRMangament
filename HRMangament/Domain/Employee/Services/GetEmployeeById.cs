using HRMangament.Domain.AccessLayer.Employees;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Services.Employees
{
    public interface IGetEmployeeById
    {
        Employee Excute(int employeeId);
    }
    public class GetEmployeeById : IGetEmployeeById
    {
        private readonly IEmployeeDataAdapter _employeeDataAdapter;

        public GetEmployeeById(IEmployeeDataAdapter employeeDataAdapter)
        {
            _employeeDataAdapter = employeeDataAdapter;
        }
        public Employee Excute(int employeeId)
        {
            return _employeeDataAdapter.GetEmployeeById(employeeId);
        }
    }
}
