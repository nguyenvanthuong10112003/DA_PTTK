using Program.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Program.Models
{
    public class AccountModel
    {
        private QLNVContext context { set; get; } = null;
        
        public AccountModel() { 
            context = new QLNVContext();
        }

        public TaiKhoan findTaiKhoanByUsername(string username)
        {
            TaiKhoan taiKhoan = null;
            taiKhoan = context.Database.SqlQuery<TaiKhoan>("proc_findTaiKhoan_ByUsername @username", 
                new[]{new SqlParameter("@username", username)}).SingleOrDefault();
            return taiKhoan;
        }

        public bool checkLoginByCookie(Account account)
        {
            object[] parameters = new object[] { 
                new SqlParameter("@username", account.username), 
                new SqlParameter("@password", account.password)
            };
            var isLogin = context.Database.SqlQuery<bool>("proc_checkLogin_ByCookie @username, @password", parameters)
                .SingleOrDefault();
            return isLogin;
        }
    }
}