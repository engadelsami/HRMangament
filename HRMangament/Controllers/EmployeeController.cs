using HRMangament.Domain.Employees.Commands;
using HRMangament.Domain.Services.Employees;
using HRMangament.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IGetEmployees _getEmployees;
        private readonly IAddEmployee _addEmployee;
        private readonly IDeleteEmployee _deleteEmployee;
        private readonly IUpdateEmployee _updateEmployee;
        private readonly IGetEmployeeById _getEmployeeById;



        public EmployeeController(IGetEmployees getEmployees,IAddEmployee addEmployee ,
                                IDeleteEmployee deleteEmployee, IUpdateEmployee updateEmployee, IGetEmployeeById getEmployeeById)
        {
            _getEmployees = getEmployees;
            _addEmployee = addEmployee;
            _deleteEmployee = deleteEmployee;
            _updateEmployee = updateEmployee;
            _getEmployeeById = getEmployeeById;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return new JsonResult(_getEmployees.Excute());
        }

        public IActionResult GetEmployeeById(int employeeId)
        {
            return new JsonResult(_getEmployeeById.Excute(employeeId));
        }

        [HttpPost]
        public IActionResult AddEmployee( AddEmployeeCommand employee )
        {
            _addEmployee.Excute(employee);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteEmployee(int employeeId)
        {
            _deleteEmployee.Excute(employeeId);
            return Ok();
        }

        public IActionResult UpdateEmployee(UpdateEmployeeCommand employee)
        {
            _updateEmployee.Excute(employee);
            return Ok();
        }
    }
}
