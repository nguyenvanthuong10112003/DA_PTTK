using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Program.Models;
using Program.Models.DAO;
using Program.Models.DB;

namespace Program.Controllers
{
    public class ThanhVienController : Controller
    {
        // GET: ThanhVien
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAll(int page = 1, int size = 1)
        {
            List<ThanhVien> list = new DBModel<ThanhVien>().getDataForPage(Define.DefineProcSQL.getThanhViensByPage, page, size);
            return Json(new
            {
                data = list,
                name = ThanhVien.getNameItems()
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Profile(string ma) {
            ThanhVien thanhVien = new ThanhVienDAO().getThanhVienByCode(ma);
            return View(thanhVien);
        }

        public JsonResult delete(string[] ma)
        {
            return Json(new { });
        }

        public JsonResult add(string ma)
        {
            return Json(new { });
        }

        public JsonResult update(string ma)
        {
            return Json(new { });
        }
    }
}