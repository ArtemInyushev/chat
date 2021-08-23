using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Models {
    public class AuthOptions {
        public AuthOptions(string secret) {
            KEY = secret;
        }
        public readonly string ISSUER = "MyAuthServer"; // издатель токена
        public readonly string AUDIENCE = "MyAuthClient"; // потребитель токена
        private readonly string KEY = String.Empty;
        public readonly int LIFETIME_MONTH = 3; // время жизни токена - 1 месяц
        public SymmetricSecurityKey GetSymmetricSecurityKey() {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
