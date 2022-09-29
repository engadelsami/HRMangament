using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Models
{
    public class Organizations
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int      OrganizationId          { get; set; }
        public string   OrganizationName        { get; set; }
        public DateTime subscribtionStartDate   { get; set; }
        public DateTime subscribtionEndDate     { get; set; }
        public int      MaxEmployeesNumber      { get; set; }

    }
}
