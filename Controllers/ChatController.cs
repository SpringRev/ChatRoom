using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatRoom.Controllers
{
    public class ChatController : Controller
    {
        /// <summary>
        /// Controller to render the chat view
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Chat()
        {
            return View();
        }
      
    }
}