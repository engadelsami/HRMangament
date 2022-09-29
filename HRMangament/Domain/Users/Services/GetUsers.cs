using HRMangament.Domain.Userses.Commands;
using HRMangament.Domain.Userses.AccessLayer;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Userses.Services
{
    public interface IGetUsers
    {
        List<GetUsersCommand> Excute();
    }
    public class GetUsers: IGetUsers
    {
        public readonly IUsersDataAdapter _usersDataAdapter;
        public GetUsers(IUsersDataAdapter usersDataAdapter)
        {
            _usersDataAdapter = usersDataAdapter;
        }
        public List<GetUsersCommand> Excute()
        {
            var Users = new List<GetUsersCommand>();

            foreach (var item in _usersDataAdapter.GetUsers())
            {
                var model = new GetUsersCommand();

                model.UserId = item.UserId;
                model.UserName = item.UserName;
                model.Email = item.Email;
                model.RoleId = item.RoleId;
                model.OrganizationId = item.OrganizationId;
                model.Password = item.Password;

                Users.Add(model);
            }
            return Users;

        }
    }
}
