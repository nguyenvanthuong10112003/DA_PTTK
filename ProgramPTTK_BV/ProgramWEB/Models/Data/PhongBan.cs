namespace ProgramWEB.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhongBan")]
    public partial class PhongBan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhongBan()
        {
            BoPhans = new HashSet<BoPhan>();
        }

        [Key]
        public long PB_Ma { get; set; }

        [Required]
        [StringLength(50)]
        public string PB_Ten { get; set; }

        [StringLength(50)]
        public string PB_VaiTro { get; set; }

        public long? NS_Ma { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoPhan> BoPhans { get; set; }

        public virtual NhanSu NhanSu { get; set; }
    }
}
