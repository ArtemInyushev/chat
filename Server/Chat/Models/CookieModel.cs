﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Models {
    public class CookieModel {
        public string CookieName { get; }
        public CookieModel(string name) {
            CookieName = name;
        }
    }
}
