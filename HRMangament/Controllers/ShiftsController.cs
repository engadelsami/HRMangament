using HRMangament.Domain.Shiftses.Commands;
using HRMangament.Domain.Shiftses.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Controllers
{
    public class ShiftsController : ControllerBase
    {
        private readonly IGetShifts     _getShifts;
        private readonly IAddShift      _addShift;
        private readonly IDeleteShift   _deleteShift;
        private readonly IUpdateShift   _updateShift;
        private readonly IGetShiftById  _getShiftById;

        public ShiftsController(IGetShifts getShifts, IAddShift addShift, IDeleteShift deleteShift, IUpdateShift updateShift,
                                IGetShiftById getShiftById)
        {
            _getShifts   = getShifts;
            _addShift    = addShift;
            _deleteShift = deleteShift;
            _updateShift = updateShift;
            _getShiftById= getShiftById;
        }
        [HttpGet]
        public IActionResult GetShifts()
        {
            return new JsonResult(_getShifts.Excute());
        }

        public IActionResult GetShiftById(int shiftId)
        {
            return new JsonResult(_getShiftById.Excute(shiftId));
        }

        [HttpPost]
        public IActionResult AddShift( AddShiftsCommand shift)
        {
            _addShift.Excute(shift);
            return Ok();
        }

        public IActionResult DeleteShift( int shiftId)
        {
            _deleteShift.Excute(shiftId);
            return Ok();
        }

        public IActionResult UpdateShift(UpdateShiftsCommand shift)
        {
            _updateShift.Excute(shift);
            return Ok();
        }
    }

}
