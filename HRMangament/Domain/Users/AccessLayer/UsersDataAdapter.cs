using HRMangament.Domain.Userses.Commands;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Userses.AccessLayer
{
    public interface IUsersDataAdapter
    {
        List<Users> GetUsers();
        void AddUser(Users user);
        void DeleteUser(int userId);
        void UpdateUser(UpdateUserCommand user);
        Users GetUserById(int userId);
    }
    public class UsersDataAdapter: IUsersDataAdapter
    {
        private readonly HrContext _context;
        public UsersDataAdapter(HrContext context)
        {
            _context = context;
        }
        public void AddUser(Users user)
        {
            //_context.Users.Add(user);
            //_context.SaveChanges();
        }
        public void DeleteUser(int userId)
        {
            //var user = _context.Users.FirstOrDefault(e => e.Id == userId);
            //_context.Remove(user);
            //_context.SaveChanges();
        }

        public void UpdateUser(UpdateUserCommand user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }
        public Users GetUserById(int userId)
        {
            return new Users();
        }
        public List<Users> GetUsers()
        {
            return new List<Users>();
        }
    }
}
