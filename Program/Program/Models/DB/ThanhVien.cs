namespace Program.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThanhVien")]
    public partial class ThanhVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThanhVien()
        {
            BaoHiems = new HashSet<BaoHiem>();
            CongViecDaLams = new HashSet<CongViecDaLam>();
            Gopies = new HashSet<GopY>();
            HanhDongs = new HashSet<HanhDong>();
            KhenThuongs = new HashSet<KhenThuong>();
            NganHangs = new HashSet<NganHang>();
            TaiKhoans = new HashSet<TaiKhoan>();
            ThongBaos = new HashSet<ThongBao>();
            TongKetLuongs = new HashSet<TongKetLuong>();
            ViPhams = new HashSet<ViPham>();
        }

        [Key]
        [StringLength(10)]
        public string TV_Ma { get; set; }

        [StringLength(50)]
        public string TV_HoVaTen { get; set; }

        public bool? TV_GioiTinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TV_NgaySinh { get; set; }

        [StringLength(10)]
        public string TV_SoDienThoai { get; set; }

        [StringLength(100)]
        public string TV_Email { get; set; }

        [Column(TypeName = "ntext")]
        public string TV_DiaChi { get; set; }

        [StringLength(12)]
        public string TV_SoCCCD { get; set; }

        public double? TV_PhuCap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaoHiem> BaoHiems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CongViecDaLam> CongViecDaLams { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GopY> Gopies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HanhDong> HanhDongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhenThuong> KhenThuongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NganHang> NganHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongBao> ThongBaos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TongKetLuong> TongKetLuongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ViPham> ViPhams { get; set; }
    }
}
