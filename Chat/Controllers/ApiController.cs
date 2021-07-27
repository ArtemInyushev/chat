using Chat.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Controllers {
    [ApiController]
    public class ApiController : Controller {
        private ApplicationContext db;
        public ApiController(ApplicationContext context) {
            db = context;
        }
        [HttpGet("")]
        public async Task<ActionResult> Index() {
            //List<User> users = await db.Users.ToListAsync();
            return await Task.Run(() => View());
        }
    }
}
