using Program.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Program.Models.DAO
{
    public class ThanhVienDAO
    {
        private QLNVContext context = null;
        public ThanhVienDAO()
        {
            context = new QLNVContext();
        }
        public ThanhVien getThanhVienByCode(String code)
        {
            return context.ThanhViens.Find(code);
        }
        public List<ThanhVien> getList()
        {
            return context.ThanhViens.ToList();
        }
        public ThanhVien getFullInfoThanhVienByCode(string code)
        {
            ThanhVien thanhVien = context.ThanhViens.Find(code);
            //thanhVien.CongViecDaLams = context.CongViecDaLams.w
            return thanhVien;
        }
        public ThanhVien getThanhVienByEmail(string email)
        {
            return context.ThanhViens.Where(e => e.TV_Email == email).FirstOrDefault();
        }
    }
}