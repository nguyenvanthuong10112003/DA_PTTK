using Program.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Program.Models.DAO
{
    public class TaiKhoanDAO
    {
        private QLNVContext context { set; get; } = null;
        public TaiKhoanDAO()
        {
            context = new QLNVContext();
        }
        public TaiKhoan getTaiKhoanByUsername(string username)
        {
            return context.TaiKhoans.Find(username);
        }
        public bool checkLocked(TaiKhoan taiKhoan)
        {
            if (taiKhoan != null) {
                if (taiKhoan.TK_BiKhoa == true)
                {
                    if (taiKhoan.TK_ThoiGianMoKhoa != null && 
                        taiKhoan.TK_ThoiGianMoKhoa <= DateTime.Now)
                    {
                        changeLocked(taiKhoan);
                        return false;
                    }
                }
                else
                    return false;
            }
            return true;
        }
        public void changeLocked(TaiKhoan taiKhoan) {
            if (taiKhoan != null)
            {
                taiKhoan = context.TaiKhoans.Find(taiKhoan.TK_TenDangNhap);
                if (taiKhoan != null)
                {
                    taiKhoan.TK_BiKhoa = !taiKhoan.TK_BiKhoa;
                    context.SaveChanges();
                }
            }
        }
    }
}