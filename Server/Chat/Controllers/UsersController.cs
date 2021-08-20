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
    public class UsersController : Controller {
        private DatabaseManager repository;
        public UsersController(DatabaseManager rep) {
            repository = rep;
        }
        private void SetToken(string token, string cookieName) {
            Response.Cookies.Append(cookieName, token, new CookieOptions {
                HttpOnly = false,
                Secure = true,
                IsEssential = true,
                SameSite = SameSiteMode.None,
        });
        }
        [HttpGet("Authenticate")]
        public async Task<IActionResult> AuthenticateUser() {
            //todo remove useless lines
            if (!String.IsNullOrEmpty(User.Identity.Name)) {
                return await Task.FromResult(StatusCode(200));
            }
            return await Task.FromResult(StatusCode(401));

        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserModel loginUserModel, [FromServices] CookieModel cookie) {
            User user = await this.repository.CheckIfUserExists(loginUserModel.Username, this.repository.HashPassword(loginUserModel.Password));
            if(user == null) {
                return StatusCode(401, "Wrong credentials");
            }
            string token = this.repository.GetUserToken(user.Id, loginUserModel.RememberMe);
            SetToken(token, cookie.CookieName);
            UserDataModel userData = new UserDataModel(user.Username, user.LogoUrl, user.Email);
            return StatusCode(200, userData);
        }
        [HttpGet("Logout")]
        public async Task<IActionResult> LogoutUser([FromServices] CookieModel cookie) {
            Response.Cookies.Delete(cookie.CookieName);
            return await Task.FromResult(StatusCode(200));
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
            user.Id = await this.repository.AddUser(user);

            string token = this.repository.GetUserToken(user.Id, newUserModel.RememberMe);
            SetToken(token, cookie.CookieName);
            UserDataModel userData = new UserDataModel(user.Username, user.LogoUrl, user.Email);
            return StatusCode(201, userData);
        }
    }
}
