using Program.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Program.Models;
using Program.Define;
using System.Security.Principal;

namespace Program.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            if (ModelState.IsValid)
            {
                if (Session[DefineSession.userSession] != null)
                    return RedirectToAction("Start", "Home");
                if (Request.Cookies[DefineCookie.cookieUsername] != null && Request.Cookies[DefineCookie.cookiePassword] != null) {
                    string username = Request.Cookies[DefineCookie.cookieUsername].Value;
                    string password = Request.Cookies[DefineCookie.cookiePassword].Value;
                    if (new AccountModel().checkLoginByCookie(new Account(username, password)))
                    {
                        ThanhVien thanhVien = new MemberModel().findThanhVienByUsername(username);
                        if (thanhVien != null)
                        {
                            Session.Add(DefineSession.userSession, thanhVien);
                            return RedirectToAction("Start", "Home");
                        }
                    }    
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account account)
        {
            if (ModelState.IsValid)
            {
                TaiKhoan taiKhoan = new AccountModel().findTaiKhoanByUsername(account.username);
                if (taiKhoan != null)
                    if (BCrypt.Net.BCrypt.Verify(account.password, taiKhoan.TK_MatKhau))
                    {
                        ThanhVien thanhVien = new MemberModel().findThanhVienByUsername(account.username);
                        if (thanhVien == null)
                        {
                            ModelState.AddModelError("", "Có lỗi xảy ra, vui lòng thử lại.");
                            return View(account);
                        }
                        if (account.remember)
                        {
                            DateTime dateTime = DateTime.Now.AddDays(30);
                            Response.AppendCookie(
                                new HttpCookie(DefineCookie.cookieUsername, taiKhoan.TK_TenDangNhap) { 
                                    Expires = dateTime, Secure = true
                                }
                            );
                            Response.AppendCookie(
                                new HttpCookie(DefineCookie.cookiePassword, taiKhoan.TK_MatKhau) { 
                                    Expires = dateTime, Secure = true
                                }
                            );
                        }
                        Session.Add(DefineSession.userSession, thanhVien);
                        return RedirectToAction("Start", "Home");
                    }
                ModelState.AddModelError("", "Thông tin đăng nhập không chính xác, vui lòng thử lại.");
            } else 
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
            return RedirectToAction("Start", "Home");
        }

        public ActionResult Register() {
            return View();
        }
    }
}