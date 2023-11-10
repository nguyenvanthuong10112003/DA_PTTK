using Program.Models.DB;
using Program.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Program.Models;

namespace Program.Controllers
{
    public class ManagementController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ThanhVien() 
        {
            ViewBag.countData = new ThanhVienDAO().getList().Count();
            return View();
        }
        public ActionResult PhongBan()
        {
            return View();
        }
        public ActionResult BoPhan()
        {
            return View();
        }
        public ActionResult CongViec()
        {
            return View();
        }
        public ActionResult Luong()
        {
            return View();
        }
        public ActionResult HoaDon()
        {
            return View();
        }
        public ActionResult ViPham()
        {
            return View();
        }
        public ActionResult KhenThuong()
        {
            return View();
        }
    }
}