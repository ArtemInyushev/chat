﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Models {
    public class User {
        public long Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public DateTime RegisteredAt { get; set; }
        public string LogoUrl { get; set; }
        public string Email { get; set; }
    }
    public class LoginUserModel {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
    public class NewUserModel {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
    public class UserDataModel {
        public UserDataModel(string username, string url, string email) {
            Username = username;
            LogoUrl = url;
            Email = email;
        }
        public string Username { get; set; }
        public string LogoUrl { get; set; }
        public string Email { get; set; }
    }
}
