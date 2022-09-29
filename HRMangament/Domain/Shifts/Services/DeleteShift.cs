using HRMangament.Domain.Shiftses.AccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Shiftses.Services
{
    public interface IDeleteShift
    {
        void Excute(int shiftId);
    }
    public class DeleteShift: IDeleteShift
    {
        private readonly IShiftsDataAdapter _shiftsDataAdapter;

        public DeleteShift(IShiftsDataAdapter shiftsDataAdapter)
        {
            _shiftsDataAdapter = shiftsDataAdapter;
        }
        public void Excute(int shiftId)
        {
            _shiftsDataAdapter.DeleteShift(shiftId);
        }
    }
}
