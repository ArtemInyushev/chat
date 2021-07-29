using Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Repository {
    public partial class DatabaseManager {
        private ApplicationContext db;
        public DatabaseManager(ApplicationContext context) {
            db = context;
        }
    }
}
