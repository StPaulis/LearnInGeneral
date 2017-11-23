using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebSockets.Internal;

namespace TestSignalR.Controllers
{
    //[EnableCors("http://localhost:4200/sockjs-node/460/c4o5plfd/websocket")]
    public class SignalController : Controller
    {
        
        public IActionResult SignalRChat()
        {
            return View();
        }
    }
}