using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Models
{
    public class Shifts
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ShiftId { get; set; }
        public string ShiftName { get; set; }
        [ForeignKey("Organization")]
        public int OrganizationId { get; set; }
        public DateTime StartFrom { get; set; }
        public DateTime EndTo { get; set; }
        public Organizations Organizaton { get; set; }

    }
}
