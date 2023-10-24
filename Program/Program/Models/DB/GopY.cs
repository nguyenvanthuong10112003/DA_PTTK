namespace Program.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GopY")]
    public partial class GopY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GopY()
        {
            ThongBaos = new HashSet<ThongBao>();
        }

        [Key]
        [StringLength(10)]
        public string GY_Ma { get; set; }

        [StringLength(50)]
        public string GY_TieuDe { get; set; }

        [Column(TypeName = "ntext")]
        public string GY_NoiDung { get; set; }

        public DateTime? GY_ThoiGian { get; set; }

        [StringLength(10)]
        public string TV_Ma { get; set; }

        public virtual ThanhVien ThanhVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongBao> ThongBaos { get; set; }
    }
}
