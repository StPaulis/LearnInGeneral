using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace TestSignalR.Hubs
{
    public class ChatHub : Hub
    {
        public Task Send(string data)
        {
            //return Clients.All.InvokeAsync("Send", data);
            IReadOnlyList<string> test = new List<string>();
            test = new[] { "78548c9-8e5d-bfdf6e68387a" };
            return Clients.AllExcept(test).InvokeAsync("Send");
        }
    }
}