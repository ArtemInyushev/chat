using Chat.Models;
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
        private ApplicationContext db;
        public UsersController(ApplicationContext context) {
            db = context;
        }
        [HttpPost("")]
        public async Task<int> AddUser(string name, string email, string password) {
            //action to add user
            //List<User> users = await db.Users.ToListAsync();
            return await Task.Run(() => 1);
        }
    }
}
