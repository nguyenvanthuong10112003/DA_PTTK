using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Program.Define;
namespace Program.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Start()
        {
            if (ModelState.IsValid)
            {
                if (Session[DefineSession.userSession] == null)
                    return RedirectToAction("Login", "Account");
                if (Session[DefineSession.urlBeforeSession] != null)
                {
                    string[] urlBefore = (string[])Session[DefineSession.urlBeforeSession];
                    Session.Remove(DefineSession.urlBeforeSession);
                    return RedirectToAction(urlBefore[0], urlBefore[1]);
                }
            }
            return View();
        }
    }
}