using HRMangament.Domain.Userses.AccessLayer;
using HRMangament.Domain.Userses.Commands;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Userses.Services
{
    public interface IAddUser
    {
        void Excute(AddUserCommand user);
    }
    public class AddUser: IAddUser
    {
        private readonly IUsersDataAdapter _userDataAdapter;
        public AddUser(IUsersDataAdapter userDataAdapter)
        {
            _userDataAdapter = userDataAdapter;
        }

        public void Excute(AddUserCommand user)
        {
            Users newUser = new Users()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                RoleId = user.RoleId,
                OrganizationId = user.OrganizationId,
               
            };
            _userDataAdapter.AddUser(newUser);
        }
    }
}
