using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Shiftses.Commands
{
    public class UpdateShiftsCommand
    {
        public int ShiftId { get; set; }
        public string ShiftName { get; set; }
        public int OrganizationId { get; set; }
        public DateTime StartFrom { get; set; }
        public DateTime EndTo { get; set; }
    }
}
