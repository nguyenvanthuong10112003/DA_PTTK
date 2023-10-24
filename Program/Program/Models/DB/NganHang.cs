namespace Program.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NganHang")]
    public partial class NganHang
    {
        [Key]
        [StringLength(16)]
        public string NH_SoTaiKhoan { get; set; }

        [StringLength(10)]
        public string NH_Ma { get; set; }

        [StringLength(30)]
        public string NH_TenChuTaiKhoan { get; set; }

        [StringLength(10)]
        public string TV_Ma { get; set; }

        public virtual ThanhVien ThanhVien { get; set; }
    }
}
