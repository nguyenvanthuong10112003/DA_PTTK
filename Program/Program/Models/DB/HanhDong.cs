namespace Program.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HanhDong")]
    public partial class HanhDong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HanhDong()
        {
            ThongBaos = new HashSet<ThongBao>();
        }

        [Key]
        [StringLength(10)]
        public string HD_Ma { get; set; }

        [StringLength(50)]
        public string HD_TieuDe { get; set; }

        [Column(TypeName = "ntext")]
        public string HD_MoTa { get; set; }

        public DateTime? HD_ThoiGian { get; set; }

        [StringLength(10)]
        public string TV_Ma { get; set; }

        public virtual ThanhVien ThanhVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongBao> ThongBaos { get; set; }
    }
}
