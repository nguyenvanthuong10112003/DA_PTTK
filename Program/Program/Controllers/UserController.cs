using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Program.Define;
namespace Program.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Profile()
        {
            if (Session[DefineSession.userSession] == null)
            {
                Session.Add(DefineSession.urlBeforeSession, new string[] { "Profile", "User" });
                return RedirectToAction("Start", "Home");
            }
            return View();
        }
    }
}