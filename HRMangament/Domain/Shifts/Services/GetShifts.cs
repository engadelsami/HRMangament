using HRMangament.Domain.Shiftses.Commands;
using HRMangament.Domain.Shiftses.AccessLayer;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Shiftses.Services
{
    public interface IGetShifts
    {
        List<GetShiftsCommand> Excute();
    }
    public class GetShifts: IGetShifts
    {
        public readonly IShiftsDataAdapter _shiftsDataAdapter;
        public GetShifts(IShiftsDataAdapter shiftsDataAdapter)
        {
            _shiftsDataAdapter = shiftsDataAdapter;
        }
        public List<GetShiftsCommand> Excute()
        {
            var Shifts = new List<GetShiftsCommand>();

            foreach (var item in _shiftsDataAdapter.GetShifts())
            {
                var model = new GetShiftsCommand();

                model.ShiftId = item.ShiftId;
                model.ShiftName = item.ShiftName;
                model.StartFrom = item.StartFrom;
                model.EndTo = item.EndTo;
                model.OrganizationId = item.OrganizationId;

                Shifts.Add(model);
            }
            return Shifts;

        }
    }
}
