using Microsoft.Ajax.Utilities;
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
        public TaiKhoan GetTaiKhoanByMaThanhVien(string code)
        {
            return context.TaiKhoans.Where(e => e.TV_Ma == code).FirstOrDefault();
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
        public bool Insert(TaiKhoan taiKhoan)
        {
            context.TaiKhoans.Add(taiKhoan);
            int count = context.SaveChanges();
            if (count > 0)
            {
                return true;
            }
            return false;
        }
        public bool updateTaiKhoan(TaiKhoan taiKhoan)
        {
            if (taiKhoan != null)
            {
                context.TaiKhoans.AddOrUpdate(taiKhoan);
                int count = context.SaveChanges();
                if (count >= 1)
                    return true;
            }
            return false;
        }
        public List<TaiKhoan> getList()
        {
            return context.TaiKhoans.ToList();
        }
    }
}