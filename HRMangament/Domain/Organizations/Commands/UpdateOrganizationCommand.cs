using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Organizationses.Commands
{
    public class UpdateOrganizationCommand
    {
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public DateTime subscribtionStartDate { get; set; }
        public DateTime subscribtionEndDate { get; set; }
        public int MaxEmployeesNumber { get; set; }
    }
}
