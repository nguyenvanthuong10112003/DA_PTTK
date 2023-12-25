using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramWEB.Models.Object
{
    public class DangKyNghiLam
    {
        public long? DKNL_Ma { get; set; }
        public DateTime? DKNL_Ngay { get; set; }
        public DateTime? DKNL_ThoiGianDangKy { get; set; }
        public bool? DKNL_NghiCoPhep { get; set; }
        public string DKNL_LyDoNghi { get; set; }
        public bool? DKNL_DaDuocDuyet { get; set; }
        public long? NS_Ma { get; set; }
        public long? DDK_Ma { get; set; }
        public DangKyNghiLam()
        {
            this.DKNL_Ma = null;
            this.DKNL_Ngay = null;
            this.DKNL_ThoiGianDangKy = null;
            this.DKNL_NghiCoPhep = null;
            this.DKNL_LyDoNghi = string.Empty;
            this.DKNL_DaDuocDuyet = null;
            this.NS_Ma = null;
            this.DDK_Ma = null;
        }
    }
}