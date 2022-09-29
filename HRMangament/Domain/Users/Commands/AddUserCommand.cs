using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Userses.Commands
{
    public class AddUserCommand
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int OrganizationId { get; set; }
        public int RoleId { get; set; }
    }
}
