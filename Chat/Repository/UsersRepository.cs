using Chat.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Repository {
    public partial class DatabaseManager {
        public async Task<User> AuthenticateUser(string username, string password) {
            return await Task.Run(() => new User());
        }
        public async Task<string> CheckUserDuplicate(string username, string email) {
            User user = await (from u in this.db.Users
                               where u.Email == email ||
                               u.Username == username
                               select new User { Username = u.Username, Email = u.Email}).FirstOrDefaultAsync();
            if(user?.Username == username) {
                return "This username is already used";
            }
            else if(user?.Email == email) {
                return "This email is already used";
            }
            return "";
        }
        public async Task<long> AddUser(User user) {
            this.db.Users.Add(user);
            await this.db.SaveChangesAsync();
            return user.Id;
        }
        public async Task<User> GetUserById(int id) {
            return await (from u in this.db.Users
                         where u.Id == id
                         select u).FirstOrDefaultAsync();
        }
    }
}
