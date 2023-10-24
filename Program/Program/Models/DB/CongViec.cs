namespace Program.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CongViec")]
    public partial class CongViec
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CongViec()
        {
            CongViecDaLams = new HashSet<CongViecDaLam>();
        }

        [Key]
        [StringLength(10)]
        public string CV_Ma { get; set; }

        [StringLength(50)]
        public string CV_Ten { get; set; }

        [Column(TypeName = "ntext")]
        public string CV_MoTa { get; set; }

        public double? CV_Luong { get; set; }

        public virtual CongViecBanThoiGian CongViecBanThoiGian { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CongViecDaLam> CongViecDaLams { get; set; }
    }
}
