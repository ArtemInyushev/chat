using Chat.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Repository {
    public partial class DatabaseManager {
        public string HashPassword(string password) {
            string hash;
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, Encoding.ASCII.GetBytes(this.passwordSalt))) {
                hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(30));
            }
            return hash;
        }
        public async Task<User> CheckIfUserExists(string username, string passwordHash) {
            return await this.db.Users.FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == passwordHash);
        }
        public async Task<string> CheckUserDuplicate(string username, string email) {
            User user = await this.db.Users.FirstOrDefaultAsync(u => u.Email == email || u.Username == username);
            if(user?.Username == username) {
                return "This username is already used";
            }
            else if(user?.Email == email) {
                return "This email is already used";
            }
            return "";
        }
        public string GetUserToken(long id, bool rememberMe) {
            List<Claim> claims = new List<Claim> { 
                new Claim(ClaimsIdentity.DefaultNameClaimType, id.ToString()), 
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            DateTime now = DateTime.UtcNow;
            JwtSecurityToken jwt = new JwtSecurityToken(
                    issuer: this.authOptions.ISSUER,
                    audience: this.authOptions.AUDIENCE,
                    notBefore: now,
                    claims: claimsIdentity.Claims,
                    expires: now.AddMonths(this.authOptions.LIFETIME_MONTH),
                    signingCredentials: new SigningCredentials(this.authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)); ; ;
            string encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }
        public async Task<long> AddUser(User user) {
            this.db.Users.Add(user);
            await this.db.SaveChangesAsync();
            return user.Id;
        }
        public async Task<User> GetUserById(int id) {
            return await this.db.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
