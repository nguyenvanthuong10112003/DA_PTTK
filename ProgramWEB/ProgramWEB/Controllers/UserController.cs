using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgramWEB.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult CheckLogin(string username, string password, bool remember, string author) {
            return Json(new {});
        }
        public ActionResult ForgetPassword()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        public ActionResult Logout()
        {
            return RedirectToAction("Index","Home");
        }
    }
}