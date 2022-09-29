using HRMangament.Domain.EmployeesShiftses.Commands;
using HRMangament.Domain.EmployeesShiftses.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Controllers
{
    public class EmployeesShiftsController: ControllerBase
    {
        private readonly IGetEmployeesShifts _getEmployeesShifts;
        private readonly IAddEmployeesShifts _addEmployeesShifts;
        private readonly IDeleteEmployeesShifts _deleteEmployeesShifts;
        private readonly IUpdateEmployeesShifts _updateEmployeesShifts;
        private readonly IGetEmployeesShiftById _getEmployeesShiftById;

        public EmployeesShiftsController(IGetEmployeesShifts getEmployeesShifts, IAddEmployeesShifts addEmployeesShifts,
                                    IDeleteEmployeesShifts deleteEmployeesShifts, IUpdateEmployeesShifts updateEmployeesShifts, IGetEmployeesShiftById getEmployeesShiftById)
        {
            _getEmployeesShifts = getEmployeesShifts;
            _addEmployeesShifts = addEmployeesShifts;
            _deleteEmployeesShifts = deleteEmployeesShifts;
            _updateEmployeesShifts= updateEmployeesShifts;
            _getEmployeesShiftById = getEmployeesShiftById;
        }
        [HttpGet]
        public IActionResult GetEmployeesShifts()
        {
            return new JsonResult(_getEmployeesShifts.Excute());
        }
        [HttpGet]
        public IActionResult GetEmployeesShiftsById(int employeesShiftId)
        {
            return new JsonResult(_getEmployeesShiftById.Excute(employeesShiftId));
        }

        [HttpPost]
        public IActionResult AddEmployeesShifts( AddEmployeesShiftsCommand employeesShift)
        {
            _addEmployeesShifts.Excute(employeesShift);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteEmployeesShifts( int employeesShiftId)
        {
            _deleteEmployeesShifts.Excute(employeesShiftId);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateEmployeesShifts( UpdateEmployeesShiftsCommand employeesShift)
        {
            _updateEmployeesShifts.Excute(employeesShift);
            return Ok();
        }
    }
}
