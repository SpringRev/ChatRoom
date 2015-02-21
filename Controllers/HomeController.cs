using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChatRoom.Models;

namespace ChatRoom.Controllers
{
    public class HomeController : Controller
    {
        public static List<string> UserList;
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName)
        {
            UserList.Add(userName);
            return View("~/Chat/Chat", UserList); 
        }

        public ActionResult Index()
        {  
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

}