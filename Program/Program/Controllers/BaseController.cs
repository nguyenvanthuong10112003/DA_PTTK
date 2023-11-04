using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;
using Program.Define;
using Program.Models;
using Program.Models.DAO;
using Program.Models.DB;

namespace Program.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Lay du lieu tu session
            var userSession = (UserLogin)Session[DefineSession.userSession];
            if (userSession == null)
            {
                //Lay du lieu tu cookie
                var username = Request.Cookies[DefineCookie.cookieUsername];
                var password = Request.Cookies[DefineCookie.cookiePassword];
                if (username != null && password != null &&
                    username.Value != null && password.Value != null)
                {
                    TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
                    TaiKhoan taiKhoan = taiKhoanDAO.getTaiKhoanByUsername(username.Value);
                    if (taiKhoan != null)
                    {
                        if (taiKhoan.TK_MatKhau == password.Value)
                        {
                            if (!taiKhoanDAO.checkLocked(taiKhoan))
                            {
                                //Them vao session
                                userSession = new UserLogin(taiKhoan.TK_TenDangNhap, taiKhoan.TV_Ma);
                                Session.Add(DefineSession.userSession, userSession);
                                goto PlaceDanceWhenSuccess;
                            }
                        }
                    }
                }
                //Xoa khoi cookie
                removeFromCookie(new string[] { DefineCookie.cookieUsername, DefineCookie.cookiePassword });
                if (Session[DefineSession.beforeUrlSesstion] == null)
                    Session.Add(DefineSession.beforeUrlSesstion, new string[] { filterContext.RouteData.Values["action"].ToString(),
                                                                            filterContext.RouteData.Values["controller"].ToString()
                                                                            });
                filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(new {controller = "User", action = "Login"}));
            }
            PlaceDanceWhenSuccess:
            base.OnActionExecuting(filterContext);
        }
        public void removeFromCookie(string[]cookiesName)
        {
            DateTime dateTime = DateTime.Now.AddDays(-1);
            for (int i = 0; i < cookiesName.Length; i++)
            {
                Response.AppendCookie(
                    new HttpCookie(cookiesName[i], null)
                    {
                        Expires = dateTime,
                    }
                );
            }
        }
    }
}