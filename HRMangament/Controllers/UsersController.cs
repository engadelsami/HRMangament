using HRMangament.Domain.Userses.Commands;
using HRMangament.Domain.Userses.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Controllers
{
    public class UsersController: ControllerBase
    {
        private readonly IGetUsers      _getUsers;
        private readonly IAddUser       _addUser;
        private readonly IDeleteUser    _deleteUser;
        private readonly IUpdateUser    _updateUser;
        private readonly IGetUserById   _getUserById;

        public UsersController(IGetUsers getUsers, IAddUser addUser, IDeleteUser deleteUser, IUpdateUser updateUser, IGetUserById getUserById)
        {
            _getUsers       = getUsers   ;
            _addUser        = addUser    ;
            _deleteUser     = deleteUser ;
            _updateUser     = updateUser ;
            _getUserById = getUserById;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            return new JsonResult(_getUsers.Excute());
        }

        public IActionResult GetUserById(int userId)
        {
            return new JsonResult(_getUserById.Excute(userId));
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] AddUserCommand user)
        {
            _addUser.Excute(user);
            return Ok();
        }

        public IActionResult DeleteUser([FromBody] int userId)
        {
            _deleteUser.Excute(userId);
            return Ok();
        }

        public IActionResult UpdateUser([FromBody] UpdateUserCommand user)
        {
            _updateUser.Excute(user);
            return Ok();
        }
    }

}
