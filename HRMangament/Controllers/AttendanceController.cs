using HRMangament.Domain.Attendances.Commands;
using HRMangament.Domain.Attendances.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Controllers
{
    public class AttendanceController: ControllerBase
    {
        private readonly IGetAttendance     _getAttendance;
        private readonly IAddAttendance     _addAttendance;
        private readonly IDeleteAttendance  _deleteAttendance;
        private readonly IUpdateAttendance  _updateAttendance;
        private readonly IGetAttendanceById _getAttendanceById;

        public AttendanceController(IGetAttendance getAttendance, IAddAttendance addAttendance, 
                                    IDeleteAttendance deleteAttendance, IUpdateAttendance updateAttendance, IGetAttendanceById getAttendanceById)
        {
            _getAttendance = getAttendance;
            _addAttendance = addAttendance;
            _deleteAttendance = deleteAttendance;
            _updateAttendance = updateAttendance;
            _getAttendanceById = getAttendanceById;
        }

        [HttpGet]
        public IActionResult GetAttendance()
        {
            return new JsonResult(_getAttendance.Excute());
        }
  
        public IActionResult GetAttendanceById(int attendanceId)
        {
            return new JsonResult(_getAttendanceById.Excute(attendanceId));
        }

        [HttpPost]
        public IActionResult AddAttendance([FromBody] AddAttendanceCommand attendance)
        {
            _addAttendance.Excute(attendance);
            return Ok();
        }

        public IActionResult DeleteAttendance( int attendanceId)
        {
            _deleteAttendance.Excute(attendanceId);
            return Ok();
        }
        [HttpPost]
        public IActionResult UpdateAttendance(UpdateAttendanceCommand attendance)
        {
            _updateAttendance.Excute(attendance);
            return Ok();
        }
    }
}
