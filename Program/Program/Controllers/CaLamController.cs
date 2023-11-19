using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Program.Controllers
{
    public class CaLamController : Controller
    {
        // GET: CaLam
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LichLamViec()
        {
            return View();
        }
    }
}