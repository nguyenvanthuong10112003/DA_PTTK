namespace Program.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            TongKetLuongs = new HashSet<TongKetLuong>();
        }

        [Key]
        [StringLength(10)]
        public string HD_Ma { get; set; }

        [StringLength(50)]
        public string HD_TieuDe { get; set; }

        [Column(TypeName = "ntext")]
        public string HD_NoiDung { get; set; }

        public DateTime? HD_ThoiGian { get; set; }

        public double? HD_SoTienThanhToan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TongKetLuong> TongKetLuongs { get; set; }
    }
}
