using HRMangament.Domain.Shiftses.Commands;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Shiftses.AccessLayer
{
    public interface IShiftsDataAdapter
    {
        List<Shifts> GetShifts();
        void AddShift(Shifts shifts);
        void DeleteShift(int shiftsId);
        void UpdateShift(UpdateShiftsCommand shifts);
        Shifts GetShiftById(int shiftsId);
    }
    public class ShiftsDataAdapter:IShiftsDataAdapter
    {
        private readonly HrContext _context;
        public ShiftsDataAdapter(HrContext context)
        {
            _context = context;
        }
        public void AddShift(Shifts shift)
        {
            _context.Shifts.Add(shift);
            _context.SaveChanges();
        }

        public void DeleteShift(int shiftId)
        {
            var shift = _context.Shifts.FirstOrDefault(e => e.ShiftId == shiftId);
            _context.Remove(shift);
            _context.SaveChanges();
        }

        public void UpdateShift(UpdateShiftsCommand _shift)
        {
            var shift = _context.Shifts.FirstOrDefault(e => e.ShiftId == _shift.ShiftId);
            shift.ShiftName = _shift.ShiftName;
            shift.StartFrom = _shift.StartFrom;
            shift.EndTo = _shift.EndTo;
            shift.OrganizationId = _shift.OrganizationId;

            _context.Update(shift);
            _context.SaveChanges();
        }
        public Shifts GetShiftById(int shiftId)
        {
            return _context.Shifts.FirstOrDefault(e => e.ShiftId == shiftId);
        }
        public List<Shifts> GetShifts()
        {
            return _context.Shifts.ToList();
        }
    }
}
