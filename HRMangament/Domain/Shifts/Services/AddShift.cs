using HRMangament.Domain.Shiftses.AccessLayer;
using HRMangament.Domain.Shiftses.Commands;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Shiftses.Services
{
    public interface IAddShift
    {
        void Excute(AddShiftsCommand shifts);
    }
    public class AddShift: IAddShift
    {
        private readonly IShiftsDataAdapter _shiftsDataAdapter;
        public AddShift(IShiftsDataAdapter shiftsDataAdapter)
        {
            _shiftsDataAdapter = shiftsDataAdapter;
        }

        public void Excute(AddShiftsCommand shift)
        {
            Shifts newShift = new Shifts()
            {
                ShiftId = shift.ShiftId,
                ShiftName = shift.ShiftName,
                StartFrom = shift.StartFrom,
                EndTo = shift.EndTo,
                OrganizationId = shift.OrganizationId

            };
            _shiftsDataAdapter.AddShift(newShift);
        }
    }
}
