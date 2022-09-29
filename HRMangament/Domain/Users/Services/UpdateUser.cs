using HRMangament.Domain.Userses.AccessLayer;
using HRMangament.Domain.Userses.Commands;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Userses.Services
{
    public interface IUpdateUser
    {
        void Excute(UpdateUserCommand user);
    }
    public class UpdateUser: IUpdateUser
    {
        private readonly IUsersDataAdapter _userDataAdapter;
        public UpdateUser(IUsersDataAdapter userDataAdapter)
        {
            _userDataAdapter = userDataAdapter;
        }
        public void Excute(UpdateUserCommand user)
        {
            //var oldUser = new Users
            //{
            //    UserId = user.UserId,
            //    UserName = user.UserName,
            //    Email = user.Email,
            //    Password = user.Password,
            //    OrganizationId = user.OrganizationId,
            //    RoleId = user.RoleId

            //};
            _userDataAdapter.UpdateUser(user);
        }
    }
}
