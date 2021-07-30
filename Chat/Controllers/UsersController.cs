using Chat.Models;
using Chat.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller {
        private DatabaseManager repository;
        public UsersController(DatabaseManager rep) {
            repository = rep;
        }
        [HttpPost("")]
        public async Task<IActionResult> AddUser([FromBody] NewUserModel newUserModel) {
            string res = await repository.CheckUserDuplicate(newUserModel.Username, newUserModel.Email);
            if (!string.IsNullOrEmpty(res)) {
                return StatusCode(403, res);
            }

            User user = new User();
            user.Username = newUserModel.Username;
            user.Email = newUserModel.Email;
            user.RegisteredAt = DateTime.Now;
            //action to add user
            //List<User> users = await db.Users.ToListAsync();
            return StatusCode(201, user);
        }
    }
}
