using Program.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Program.Models;
using Program.Define;
using System.Security.Principal;
using Program.Define;
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
                if (Request.Cookies[DefineCookie.cookieUsername] != null && Request.Cookies[DefineCookie.cookiePassword] != null) {
                    string username = Request.Cookies[DefineCookie.cookieUsername].Value;
                    string password = Request.Cookies[DefineCookie.cookiePassword].Value;
                    string[,] keyValue = { { "@username", username } };
                    List<TaiKhoan> listTaiKhoan = new DBModel<TaiKhoan>().findByKeys(DefineProcSQL.findTaiKhoan, keyValue);
                    if (listTaiKhoan != null && listTaiKhoan.Count > 0 && listTaiKhoan[0].TK_MatKhau == password)
                    {
                        ThanhVien thanhVien = new DBModel<ThanhVien>().findByKeys(DefineProcSQL.findThanhVien, keyValue)[0];
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
                string[,] keyValue = { { "@username", account.username } };
                List<TaiKhoan> listTaiKhoan = new DBModel<TaiKhoan>().findByKeys(DefineProcSQL.findTaiKhoan, keyValue);
                if (listTaiKhoan != null && listTaiKhoan.Count > 0)
                    if (BCrypt.Net.BCrypt.Verify(account.password, listTaiKhoan[0].TK_MatKhau))
                    {
                        ThanhVien thanhVien = new DBModel<ThanhVien>().findByKeys(DefineProcSQL.findThanhVien, keyValue)[0];
                        if (thanhVien == null)
                        {
                            ModelState.AddModelError("", "Có lỗi xảy ra, vui lòng thử lại.");
                            return View(account);
                        }
                        if (account.remember)
                        {
                            DateTime dateTime = DateTime.Now.AddDays(30);
                            Response.AppendCookie(
                                new HttpCookie(DefineCookie.cookieUsername, listTaiKhoan[0].TK_TenDangNhap) { 
                                    Expires = dateTime, Secure = true
                                }
                            );
                            Response.AppendCookie(
                                new HttpCookie(DefineCookie.cookiePassword, listTaiKhoan[0].TK_MatKhau) { 
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