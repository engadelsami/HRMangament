using HRMangament.Domain.Userses.AccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Userses.Services
{
    public interface IDeleteUser
    {
        void Excute(int userId);
    }
    public class DeleteUser: IDeleteUser
    {
        private readonly IUsersDataAdapter _usersDataAdapter;

        public DeleteUser(IUsersDataAdapter userDataAdapter)
        {
            _usersDataAdapter = userDataAdapter;
        }
        public void Excute(int userId)
        {
            _usersDataAdapter.DeleteUser(userId);
        }
    }
}
