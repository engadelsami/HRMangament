using HRMangament.Domain.Employees.Commands;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.AccessLayer.Employees
{
    public interface IEmployeeDataAdapter
    {
        List<Employee> GetEmployees();
        void AddEmployee(Employee employee);
        void DeleteEmployee(int employeeId);
        void UpdateEmployee(UpdateEmployeeCommand employee);
        Employee GetEmployeeById(int employeeId);
    }
    public class EmployeeDataAdapter : IEmployeeDataAdapter
    {
        private readonly HrContext _context;
        public EmployeeDataAdapter(HrContext context)
        {
            _context = context;
        }

        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int employeeId)
        {
            var employee =_context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
             _context.Remove(employee);
            _context.SaveChanges();
        }

        public void UpdateEmployee(UpdateEmployeeCommand _employee)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == _employee.EmployeeId);
            employee.EmployeeFirstName = _employee.EmployeeFirstName;
            employee.EmployeeLastName = _employee.EmployeeLastName;
            employee.EmployeeGender = _employee.EmployeeGender;
            employee.Salary = _employee.Salary;
            employee.VaccationNumber = _employee.VaccationNumber;
            employee.EmployeeDOB = _employee.EmployeeDOB;
            employee.DateOfHire = _employee.DateOfHire;
            employee.FingerPrintId = _employee.FingerPrintId;
            employee.OrganizationId = _employee.OrganizationId;

            _context.Update(employee);
            _context.SaveChanges();
        }
        public Employee GetEmployeeById(int employeeId)
        {
            return _context.Employees.FirstOrDefault(e=>e.EmployeeId ==employeeId) ;
        }
        public List<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }

    }
}
