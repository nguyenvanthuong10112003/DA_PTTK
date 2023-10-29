namespace Program.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BoPhan")]
    public partial class BoPhan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BoPhan()
        {
            CongViecDaLams = new HashSet<CongViecDaLam>();
        }

        [Key]
        [StringLength(10)]
        public string BP_Ma { get; set; }

        [StringLength(50)]
        public string BP_Ten { get; set; }

        [Column(TypeName = "ntext")]
        public string BP_ChuyenMon { get; set; }

        [StringLength(10)]
        public string PB_Ma { get; set; }

        public virtual PhongBan PhongBan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CongViecDaLam> CongViecDaLams { get; set; }
    }
}
