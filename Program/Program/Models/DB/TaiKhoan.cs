namespace Program.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [Key]
        [StringLength(50)]
        public string TK_TenDangNhap { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string TK_MatKhau { get; set; }

        public bool? TK_BiKhoa { get; set; }

        public DateTime? TK_ThoiGianMoKhoa { get; set; }

        [StringLength(6)]
        public string TK_MaXacThuc { get; set; }

        public DateTime? TK_ThoiGianTaoMa { get; set; }

        [Required]
        [StringLength(10)]
        public string TV_Ma { get; set; }

        public virtual Quyen Quyen { get; set; }

        public virtual ThanhVien ThanhVien { get; set; }
        public static List<string> getNameItems()
        {
            return new List<string>()
            {
                "TK_TenDangNhap",
                "TV_BiKhoa",
                "TV_ThoiGianMoKhoa",
                "TV_QuyenQuanLy",
                "TV_QuyenAdmin"
            };
        }
    }
}
