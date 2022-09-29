using HRMangament.Domain.Shiftses.AccessLayer;
using HRMangament.Domain.Shiftses.Commands;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Shiftses.Services
{
    public interface IUpdateShift
    {
        void Excute(UpdateShiftsCommand attendance);
    }
    public class UpdateShift: IUpdateShift
    {
        private readonly IShiftsDataAdapter _shiftsDataAdapter;
        public UpdateShift(IShiftsDataAdapter shiftsDataAdapter)
        {
            _shiftsDataAdapter = shiftsDataAdapter;
        }
        public void Excute(UpdateShiftsCommand shift)
        {
            //var oldShift = new Shifts
            //{
            //    ShiftId = shift.ShiftId,
            //    ShiftName = shift.ShiftName,
            //    StartFrom = shift.StartFrom,
            //    EndTo = shift.EndTo,
            //    OrganizationId = shift.OrganizationId
            //};
            _shiftsDataAdapter.UpdateShift(shift);
        }
    }
}
