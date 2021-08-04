using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Modules {
    public class SecurityManager {
        private readonly string ServerSalt;
        public SecurityManager(string salt) {
            ServerSalt = salt;
        }
        public string HashPassword(string password) {
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, Encoding.ASCII.GetBytes(this.ServerSalt))) {
                return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(30));
            }
        }
    }
}
