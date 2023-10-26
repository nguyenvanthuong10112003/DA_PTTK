using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Program.Define
{
    public class DefineProcSQL
    {
        public static string findTaiKhoan { get; } = "proc_findTaiKhoan_ByUsername @username";
        public static string findThanhVien { get; } = "proc_findThanhVienByUsername @username";
    }
}