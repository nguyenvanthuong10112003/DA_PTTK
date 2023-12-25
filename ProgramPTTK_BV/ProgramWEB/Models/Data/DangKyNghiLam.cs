namespace ProgramWEB.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DangKyNghiLam")]
    public partial class DangKyNghiLam
    {
        [Key]
        public long DKNL_Ma { get; set; }

        [Column(TypeName = "date")]
        public DateTime DKNL_Ngay { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DKNL_ThoiGianDangKy { get; set; }

        public bool DKNL_NghiCoPhep { get; set; }

        [Column(TypeName = "ntext")]
        public string DKNL_LyDoNghi { get; set; }

        public bool DKNL_DaDuocDuyet { get; set; }

        public long NS_Ma { get; set; }

        public long? DDK_Ma { get; set; }

        public virtual DuyetDangKy DuyetDangKy { get; set; }

        public virtual NhanSu NhanSu { get; set; }
    }
}
