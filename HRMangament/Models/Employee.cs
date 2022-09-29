using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public DateTime EmployeeDOB { get; set; }
        public string EmployeeGender { get; set; }
        public DateTime DateOfHire { get; set; }
        public decimal Salary { get; set; }
        public byte IsActive { get; set; }
        [ForeignKey("Organization")]
        public int OrganizationId { get; set; }
        public int VaccationNumber { get; set; }
        public int FingerPrintId { get; set; }
        public Organizations Organizaton { get; set; }





    }
}
