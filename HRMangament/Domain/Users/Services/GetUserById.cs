using HRMangament.Domain.Userses.AccessLayer;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Userses.Services
{
    public interface IGetUserById
    {
        Users Excute(int userId);
    }
    public class GetUserById: IGetUserById
    {
        private readonly IUsersDataAdapter _usersDataAdapter;

        public GetUserById(IUsersDataAdapter userDataAdapter)
        {
            _usersDataAdapter = userDataAdapter;
        }
        public Users Excute(int userId)
        {
            return _usersDataAdapter.GetUserById(userId);
        }
    }
}
