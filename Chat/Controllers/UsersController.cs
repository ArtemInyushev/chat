using Chat.Models;
using Chat.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private void SetToken(string token, string cookieName) {
            Response.Cookies.Append(cookieName, token, new CookieOptions {
                HttpOnly = true,
                Secure = true,
                IsEssential = true,
            });
        }
        [HttpGet("Authenticate")]
        public async Task<IActionResult> AuthenticateUser() {
            if (!String.IsNullOrEmpty(User.Identity.Name)) {
                return StatusCode(200);
            }
            return StatusCode(401);

        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserModel loginUserModel, [FromServices] CookieModel cookie) {
            User user = await this.repository.CheckIfUserExists(loginUserModel.Username, this.repository.HashPassword(loginUserModel.Password));
            if(user == null) {
                return StatusCode(401, "Wrong credentials");
            }
            string token = this.repository.GetUserToken(user.Id);
            SetToken(token, cookie.CookieName);
            return StatusCode(200, user);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddUser([FromBody] NewUserModel newUserModel, [FromServices] CookieModel cookie) {
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
            SetToken(token, cookie.CookieName);
            return StatusCode(201, user);
        }
    }
}
