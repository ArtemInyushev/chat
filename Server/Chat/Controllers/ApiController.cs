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
        [HttpGet("")]
        public async Task<ActionResult> Index() {
            return await Task.Run(() => View());
        }
    }
}
