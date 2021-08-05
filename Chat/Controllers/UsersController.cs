using Chat.Models;
using Chat.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Chat.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
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
            user.PasswordHash = this.repository.HashPassword(newUserModel.Password);
            //user.Id = await this.repository.AddUser(user);

            string token = this.repository.GetUserToken(user.Id);
            Response.Cookies.Append(".AspNetCore.User.Id", token);
            return StatusCode(201, user);
        }
        [HttpGet("")]
        [Authorize]
        public async Task<IActionResult> GetAllUsers() {
            return StatusCode(200, $"Ваш логин: {User.Identity.Name}");
        }
    }
}
