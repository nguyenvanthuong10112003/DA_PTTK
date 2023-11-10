using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Program.Define
{
    public class DefineProcSQL
    {
        public static string getThanhViensByPage { get; } = "PROC_ThanhVien_GetDatas_ByNumericalOrder @Page, @PageSize";
        public static string findTaiKhoanByUsername { get; } = "proc_TaiKhoan_GetData_ByUsername @username";
        public static string findThanhVienByCode { get; } = "proc_ThanhVien_GetData_ByCode @code";
        public static string findThanhVienByEmail { get; } = "PROC_ThanhVien_GetData_ByEmail @email";
        public static string findTaiKhoanByThanhVienCode { get; } = "PROC_TaiKhoan_GetData_ByTV_CODE @code";
    }
}