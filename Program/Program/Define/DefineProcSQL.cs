﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Program.Define
{
    public class DefineProcSQL
    {
        public static string findTaiKhoanByUsername { get; } = "proc_TaiKhoan_GetData_ByUsername @username";
        public static string findThanhVienByCode { get; } = "proc_ThanhVien_GetData_ByCode @code";
    }
}