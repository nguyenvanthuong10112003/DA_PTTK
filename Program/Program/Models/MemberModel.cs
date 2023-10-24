using Program.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Program.Models
{
    public class MemberModel
    {
        private QLNVContext context { set; get; } = null;
        public MemberModel() { 
            context = new QLNVContext();
        }
        public ThanhVien findThanhVienByUsername(string username)
        {
            ThanhVien thanhVien = null;
            thanhVien = context.Database.SqlQuery<ThanhVien>("proc_findThanhVienByUsername @username",
                new[] { new SqlParameter("@username", username) }).SingleOrDefault();
            return thanhVien;
        }
    }
}