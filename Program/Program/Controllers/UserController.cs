using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Program.Define;
using Program.Models;
using Program.Models.DAO;
using Program.Models.DB;

namespace Program.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            if (ModelState.IsValid)
            {
                if ((UserLogin)Session[DefineSession.userSession] != null)
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
                                ModelState.AddModelError("", message);
                            }
                            else
                            {
                                //Neu duy tri dang nhap, them vao cookie
                                if (account.remember)
                                {
                                    DateTime dateTime = DateTime.Now.AddDays(30);
                                    Response.AppendCookie(
                                        new HttpCookie(DefineCookie.cookieUsername, taiKhoan.TK_TenDangNhap)
                                        {
                                            Expires = dateTime,
                                            Secure = true
                                        }
                                    );
                                    Response.AppendCookie(
                                        new HttpCookie(DefineCookie.cookiePassword, taiKhoan.TK_MatKhau)
                                        {
                                            Expires = dateTime,
                                            Secure = true
                                        }
                                    );
                                }
                                //Them vao session
                                var userSession = new UserLogin(taiKhoan.TK_TenDangNhap, taiKhoan.TV_Ma);
                                Session.Add(DefineSession.userSession, userSession);
                                return RedirectToAction("Index", "Home");
                            }
                        }
                        else
                            ModelState.AddModelError("", "Thông tin đăng nhập không chính xác, vui lòng thử lại.");
                    }
                    else
                        ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
            }
            else
                ModelState.AddModelError("", "Có lỗi xảy ra, vui lòng thử lại.");
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

        public ActionResult Register()
        {
            if (ModelState.IsValid)
            {
                if ((UserLogin)Session[DefineSession.userSession] != null)
                    return RedirectToAction("Index", "Home");
            }
            return View();
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
                } else 
                    return RedirectToAction("Login", "User");
            }
            return View(thanhVien);
        }
    }
}