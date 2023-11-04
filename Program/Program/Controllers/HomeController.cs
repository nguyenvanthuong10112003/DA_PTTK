using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Program.Define;
namespace Program.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            string[] beforeURL = (string[])Session[DefineSession.beforeUrlSesstion];
            if (beforeURL != null)
            {
                Session.Remove(DefineSession.beforeUrlSesstion);
                return RedirectToAction(beforeURL[0], beforeURL[1]);
            }
            return View();
        }

        public ActionResult Start()
        {
            return View();
        }
    }
}