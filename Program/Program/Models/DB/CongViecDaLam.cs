namespace Program.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CongViecDaLam")]
    public partial class CongViecDaLam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CongViecDaLam()
        {
            ChamCongs = new HashSet<ChamCong>();
            NghiLams = new HashSet<NghiLam>();
        }

        [Key]
        [StringLength(10)]
        public string CVDL_Ma { get; set; }

        [Column(TypeName = "date")]
        public DateTime CVDL_NgayBatDauLam { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CVDL_NgayKetThucLam { get; set; }

        [Column(TypeName = "ntext")]
        public string CVDL_GhiChu { get; set; }

        public bool CVDL_PartOrFull { get; set; }

        [StringLength(20)]
        public string CVDL_ChucVu { get; set; }

        [StringLength(10)]
        public string CV_Ma { get; set; }

        [StringLength(10)]
        public string BP_Ma { get; set; }

        [StringLength(10)]
        public string TV_Ma { get; set; }

        public virtual BoPhan BoPhan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChamCong> ChamCongs { get; set; }

        public virtual CongViec CongViec { get; set; }

        public virtual ThanhVien ThanhVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NghiLam> NghiLams { get; set; }
    }
}
