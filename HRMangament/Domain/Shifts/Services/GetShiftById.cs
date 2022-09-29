using HRMangament.Domain.Shiftses.AccessLayer;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Shiftses.Services
{
    public interface IGetShiftById
    {
        Shifts Excute(int shiftId);
    }
    public class GetShiftById: IGetShiftById
    {
        private readonly IShiftsDataAdapter _shiftsDataAdapter;

        public GetShiftById(IShiftsDataAdapter shiftsDataAdapter)
        {
            _shiftsDataAdapter = shiftsDataAdapter;
        }
        public Shifts Excute(int shiftId)
        {
            return _shiftsDataAdapter.GetShiftById(shiftId);
        }
    }
}
