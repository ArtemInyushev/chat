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
        private DatabaseManager db;
        public UsersController(DatabaseManager database) {
            db = database;
        }
        [HttpPost("")]
        public async Task<int> AddUser([FromBody] NewUserModel newUserModel) {
            string res = await db.CheckUserDuplicate(newUserModel.Username, newUserModel.Email);

            User user = new User();
            user.Username = newUserModel.Username;
            user.Email = newUserModel.Email;
            user.RegisteredAt = DateTime.Now;
            //action to add user
            //List<User> users = await db.Users.ToListAsync();
            return await Task.Run(() => 1);
        }
    }
}
