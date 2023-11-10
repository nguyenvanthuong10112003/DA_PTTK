using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Principal;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Program.Define;
using Program.Libary;
using Program.Models;
using Program.Models.DAO;
using Program.Models.DB;
using WebGrease.Css.Ast;

namespace Program.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            if (ModelState.IsValid)
            {
                if ((UserLogin)Session[DefineSession.userSession] != null ||
                    Request.Cookies[DefineCookie.cookieUsername] != null)
                    return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(Account account)
        {
            if (ModelState.IsValid)
            {
                if (account != null)
                {
                    TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
                    TaiKhoan taiKhoan = taiKhoanDAO.getTaiKhoanByUsername(account.username);
                    //Kiem tra tai khoan ton tai
                    if (taiKhoan != null)
                    {
                        if (BCrypt.Net.BCrypt.Verify(account.password, taiKhoan.TK_MatKhau))
                        {
                            //Kiem tra tai khoan bi khoa
                            if (taiKhoanDAO.checkLocked(taiKhoan))
                            {
                                string message = "Tài khoản của bạn đã bị khóa";
                                if (taiKhoan.TK_ThoiGianMoKhoa == null)
                                {
                                    message += " vĩnh viễn.";
                                }
                                else
                                {
                                    message += ". Vui lòng thử lại sau vào " + taiKhoan.TK_ThoiGianMoKhoa.ToString();
                                }
                                ViewBag.error =  message;
                            }
                            else
                            {
                                //Neu duy tri dang nhap, them vao cookie
                                if (account.remember)
                                {
                                    DateTime dateTime = DateTime.Now.AddDays(30);
                                    addToCookies(DefineCookie.cookiePassword, taiKhoan.TK_MatKhau, dateTime);
                                    addToCookies(DefineCookie.cookieUsername, taiKhoan.TK_TenDangNhap, dateTime);
                                }
                                //Them vao session
                                var userSession = new UserLogin(taiKhoan.TK_TenDangNhap, taiKhoan.TV_Ma);
                                Session.Add(DefineSession.userSession, userSession);
                                return RedirectToAction("Index", "Home");
                            }
                        }
                        else
                            ViewBag.error = "Thông tin đăng nhập không chính xác, vui lòng thử lại.";
                    }
                    else
                        ViewBag.error = "Tài khoản không tồn tại.";
                }
            }
            else
                ViewBag.error = "Có lỗi xảy ra, vui lòng thử lại.";
            return View(account);
        }

        public ActionResult Logout()
        {
            if (ModelState.IsValid)
            {
                DateTime dateTime = DateTime.Now.AddDays(-1);
                Response.AppendCookie(
                    new HttpCookie(DefineCookie.cookieUsername, null)
                    {
                        Expires = dateTime,
                    }
                );
                Response.AppendCookie(
                    new HttpCookie(DefineCookie.cookiePassword, null)
                    {
                        Expires = dateTime,
                    }
                );
                Session.Remove(DefineSession.userSession);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Register()
        {
            if (ModelState.IsValid)
            {
                if ((UserLogin)Session[DefineSession.userSession] != null ||
                    Request.Cookies[DefineCookie.cookieUsername] != null)
                    return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Register(Account account)
        {
            if (ModelState.IsValid)
            {
                if (account != null)
                {
                    TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
                    ThanhVienDAO thanhVienDAO = new ThanhVienDAO();
                    account.password = BCrypt.Net.BCrypt.HashPassword(account.password);
                    //Kiem tra tai khoan ton tai
                    if (taiKhoanDAO.getTaiKhoanByUsername(account.username) == null)
                    {
                        if (!account.checkUsingEmail())
                        {
                            TaiKhoan taiKhoan = new DBModel<TaiKhoan>().findDataByKeys(DefineProcSQL.findTaiKhoanByThanhVienCode,
                                new string[,] { { "@code", account.code } });
                            if (taiKhoan == null)
                            {
                                if (thanhVienDAO.getThanhVienByCode(account.code) != null)
                                {
                                    taiKhoan = Validate.validateTaiKhoan(account);
                                    if (!taiKhoanDAO.Insert(taiKhoan))
                                        ViewBag.error = "Tạo tài khoản thất bại, vui lòng thử lại";
                                    else
                                        ViewBag.success = "Đăng ký tài khoản thành công";
                                    account = null;
                                }
                                else
                                    ViewBag.error = "Mã của bạn không tồn tại trong hệ thống";
                            } else
                                ViewBag.error = "Tồn tại tài khoản ứng với mã của bạn trong hệ thống, không thể thêm";
                        } else
                        {
                            ThanhVien thanhVien = new DBModel<ThanhVien>().findDataByKeys(DefineProcSQL.findThanhVienByEmail,
                                new string[,] { { "@email", account.email } });
                            if (thanhVien != null)
                            {
                                TaiKhoan taiKhoan = new DBModel<TaiKhoan>().findDataByKeys(DefineProcSQL.findTaiKhoanByThanhVienCode,
                                    new string[,] { { "@code", thanhVien.TV_Ma } });
                                if (taiKhoan == null)
                                {
                                    account.code = thanhVien.TV_Ma;
                                    taiKhoan = Validate.validateTaiKhoan(account);
                                    if (!taiKhoanDAO.Insert(taiKhoan))
                                        ViewBag.error = "Tạo tài khoản thất bại, vui lòng thử lại";
                                    else
                                        ViewBag.success = "Đăng ký tài khoản thành công";
                                    account = null;
                                }
                                else
                                    ViewBag.error = "Tồn tại tài khoản ứng với email của bạn trong hệ thống, không thể thêm";
                            }
                            else
                                ViewBag.error = "Email của bạn không tồn tại trong hệ thống";
                        }
                    }
                    else
                        ViewBag.error = "Tên đăng nhập đã tồn tại";
                }      
            }
            return View(account);
        }
        public ActionResult ChangePassword()
        {
            if (ModelState.IsValid)
            {
                UserLogin userLogin = (UserLogin)Session[DefineSession.userSession];
                if (userLogin == null)
                {
                    Session.Remove(DefineSession.beforeUrlSesstion);
                    Session.Add(DefineSession.beforeUrlSesstion, new string[] { "ChangePassword", "User" });
                    return RedirectToAction("Index", "Home");
                }
                string oldPassword = Request["oldPassword"];
                string newPassword = Request["newPassword"];
                if (!string.IsNullOrEmpty(oldPassword) && !string.IsNullOrEmpty(newPassword))
                {
                    TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
                    TaiKhoan taiKhoan = taiKhoanDAO.getTaiKhoanByUsername(userLogin.username);
                    if (taiKhoan != null)
                    {
                        if (!BCrypt.Net.BCrypt.Verify(oldPassword, taiKhoan.TK_MatKhau))
                            ViewBag.error = "Mật khẩu cũ không chính xác";
                        else
                        {
                            taiKhoan.TK_MatKhau = BCrypt.Net.BCrypt.HashPassword(newPassword);
                            if (taiKhoanDAO.updateTaiKhoan(taiKhoan))
                            {
                                if (Request.Cookies[DefineCookie.cookiePassword] != null)
                                {
                                    DateTime dateTime = DateTime.Now.AddDays(30);
                                    addToCookies(DefineCookie.cookiePassword, taiKhoan.TK_MatKhau, dateTime);
                                    addToCookies(DefineCookie.cookieUsername, userLogin.username, dateTime);
                                }
                                ViewBag.success = "Đổi mật khẩu thành công.";
                            }
                            else
                                ViewBag.error = "Đổi mật khẩu thất bại.";
                        }
                    }
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult ForgetPassword()
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
        [HttpPost]
        public ActionResult ForgetPassword(string code, string email)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(email))
                {
                    ThanhVien thanhVien = null;
                    TaiKhoan taiKhoan = null;
                    ThanhVienDAO thanhVienDAO = new ThanhVienDAO();
                    TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
                    thanhVien = thanhVienDAO.getThanhVienByCode(code);
                    if (thanhVien == null)
                    {
                        ViewBag.error = "Không tồn tại thành viên có mã " + code + " trong hệ thống.";
                        return View();
                    }
                    if (string.IsNullOrEmpty(thanhVien.TV_Email))
                    {
                        ViewBag.error = "Thành viên có mã " + code + " không có email trong hệ thống.";
                        return View();
                    }
                    taiKhoan = taiKhoanDAO.GetTaiKhoanByMaThanhVien(thanhVien.TV_Ma);
                    if (taiKhoan == null)
                    {
                        ViewBag.error = "Thành viên có mã " + code + " chưa có tài khoản trong hệ thống.";
                        return View();
                    }
                    email = thanhVien.TV_Email;
                }
                 return RedirectToAction("Authentication", new { email = email });

            } 
            return View();
        }
        public ActionResult Authentication(string email)
        {
            if (string.IsNullOrEmpty(email))
                return RedirectToAction("NotFound", "Error");
            if (ModelState.IsValid)
            {
                TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
                ThanhVien thanhVien = new ThanhVienDAO().getThanhVienByEmail(email);
                if (thanhVien == null)
                {
                    ViewBag.error = "Không tồn tại thành viên có email " + email + "trong hệ thống.";
                    return View("ForgetPassword");
                }   
                TaiKhoan taiKhoan = taiKhoanDAO.GetTaiKhoanByMaThanhVien(thanhVien.TV_Ma);
                if (taiKhoan == null)
                {
                    ViewBag.error = "Thành viên có email " + email + " chưa có tài khoản trong hệ thống.";
                    return View("ForgetPassword");
                }
                string maXacThuc = taoMaXacThuc();
                DateTime now = DateTime.Now;
                if (sendEmail("~/Content/forms/SendEmailForgetPassword.html", thanhVien.TV_Email, "Xác nhận đặt lại mật khẩu",
                    new List<string> { "{{email}}", "{{name}}", "{{maXacThuc}}", "{{time}}", "{{companyName}}" },
                    new List<string> { thanhVien.TV_Email, thanhVien.TV_HoVaTen, maXacThuc, now.ToString(), ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString()
                }))
                {
                    taiKhoan.TK_MaXacThuc = maXacThuc;
                    taiKhoan.TK_ThoiGianTaoMa = now;
                    taiKhoanDAO.updateTaiKhoan(taiKhoan);
                    ViewBag.email = thanhVien.TV_Email;
                    return View();
                }
                else
                    ViewBag.error = "Có lỗi xảy ra, vui lòng thử lại sau";
            }
            return View("ForgetPassword");
        }

        public JsonResult checkNewPassword(string email, string newPassword)
        {
            if (string.IsNullOrEmpty(email))
                return Json(new { error = "Có lỗi xảy ra, vui lòng thử lại sau." });
            ThanhVien thanhVien = new ThanhVienDAO().getThanhVienByEmail(email);
            if (thanhVien == null)
                return Json(new { error = "Có lỗi xảy ra, vui lòng thử lại sau." });
            TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
            TaiKhoan taiKhoan = taiKhoanDAO.GetTaiKhoanByMaThanhVien(thanhVien.TV_Ma);
            if (taiKhoan == null)
                return Json(new { error = "Có lỗi xảy ra, vui lòng thử lại sau." });
            if (BCrypt.Net.BCrypt.Verify(newPassword, taiKhoan.TK_MatKhau))
                return Json(new { error = "Mật khẩu mới không được trùng mật khẩu cũ." });
            taiKhoan.TK_MatKhau = BCrypt.Net.BCrypt.HashPassword(newPassword);
            if (!taiKhoanDAO.updateTaiKhoan(taiKhoan))
                return Json(new { error = "Đổi mật khẩu thất bại." });
            return Json(new { success = "Đổi mật khẩu thành công." });
        }    
        public JsonResult checkMaXacThuc(string maXacThuc, string email)
        {
            if (string.IsNullOrEmpty(email))
                return Json(new { error = "Có lỗi xảy ra, vui lòng thử lại sau." });
            ThanhVien thanhVien = new ThanhVienDAO().getThanhVienByEmail(email);
            if (thanhVien == null)
                return Json(new { error = "Có lỗi xảy ra, vui lòng thử lại sau." });
            TaiKhoan taiKhoan = new TaiKhoanDAO().GetTaiKhoanByMaThanhVien(thanhVien.TV_Ma);
            if (taiKhoan == null)
                return Json(new { error = "Có lỗi xảy ra, vui lòng thử lại sau." });
            if (taiKhoan.TK_MaXacThuc != maXacThuc)
                return Json(new { error = "Mã xác thực không chính xác." });
            if (DateTime.Now > taiKhoan.TK_ThoiGianTaoMa.Value.AddSeconds(300))
                return Json(new { error = "Mã xác thực đã quá thời gian giới hạn." });
            return Json(new { success = "Mã xác thực chính xác, vui lòng đổi mật khẩu mới." });
        }
        public bool sendEmail(string pathForm, string toEmail, string title, List<string> keys, List<string> values)
        {
            try
            {
                string content = System.IO.File.ReadAllText(Server.MapPath(pathForm));
                for (int i = 0; i < keys.Count; i++)
                {
                    content = content.Replace(keys[i], values[i]);
                }
                EmailHelper.SendEmail(toEmail, title, content);
                return true;
            } catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public string taoMaXacThuc()
        {
            string maXacThuc = "";
            int b = 0, c = 9;
            Random random = new Random();
            for (int i = 0; i < 6; i++)
                maXacThuc += ((random.Next(c - (b - 1)) + b) + "");
            return maXacThuc;
        }
        public ActionResult Profile()
        {
            ThanhVien thanhVien = null;
            if (ModelState.IsValid)
            {
                UserLogin userLogin = (UserLogin)Session[DefineSession.userSession];
                if (userLogin != null)
                {
                    thanhVien = new DBModel<ThanhVien>().findDataByKeys(DefineProcSQL.findThanhVienByCode, 
                        new string[,] { {"@code", userLogin.code} });
                }
                else {
                    Session.Remove(DefineSession.beforeUrlSesstion);
                    Session.Add(DefineSession.beforeUrlSesstion, new string[] { "Profile", "User" });
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(thanhVien);
        }

        public void addToCookies(string key, string value, DateTime date)
        {
            Response.AppendCookie(new HttpCookie(key, value) { Expires = date });
        }
    }
}