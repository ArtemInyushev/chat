using Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Repository {
    public partial class DatabaseManager {
        private ApplicationContext db;
        private AuthOptions authOptions;
        private readonly string passwordSalt;
        public DatabaseManager(ApplicationContext context, AuthOptions options, string salt) {
            db = context;
            authOptions = options;
            passwordSalt = salt;
        }
    }
}
