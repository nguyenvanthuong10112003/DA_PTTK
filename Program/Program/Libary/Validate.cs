using Program.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Program.Models
{
    public class Validate
    {
        public static TaiKhoan validateTaiKhoan(Account account)
        {
            TaiKhoan taiKhoan = new TaiKhoan();
            taiKhoan.TV_Ma = account.code;
            taiKhoan.TK_TenDangNhap = account.username;
            taiKhoan.TK_MatKhau = account.password;
            return taiKhoan;
        }
    }
}