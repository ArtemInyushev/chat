﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Modules {
    public class ChatHub : Hub {
        public override async Task OnConnectedAsync() {
            var tmp = Clients;
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception exception) {
            await base.OnDisconnectedAsync(exception);
        }
    }
}
