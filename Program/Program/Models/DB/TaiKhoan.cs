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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            ThanhViens = new HashSet<ThanhVien>();
        }

        [Key]
        [StringLength(50)]
        public string TK_TenDangNhap { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string TK_MatKhau { get; set; }

        [StringLength(6)]
        public string TK_MaXacThuc { get; set; }

        [StringLength(6)]
        public string TK_MaBaoVe { get; set; }

        public DateTime? TK_ThoiGianTaoMa { get; set; }

        public virtual Quyen Quyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThanhVien> ThanhViens { get; set; }
    }
}
