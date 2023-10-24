namespace Program.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Quyen")]
    public partial class Quyen
    {
        [Key]
        [StringLength(50)]
        public string TK_TenDangNhap { get; set; }

        public bool? Q_QuanLyTTCN { get; set; }

        public bool? Q_XemTTHT { get; set; }

        public bool? Q_SuaTTHT { get; set; }

        public bool? Q_ThemTTHT { get; set; }

        public bool? Q_CapQuyen { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
