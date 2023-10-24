namespace Program.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LuatLe")]
    public partial class LuatLe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LuatLe()
        {
            ViPhams = new HashSet<ViPham>();
        }

        [Key]
        [StringLength(10)]
        public string LL_Ma { get; set; }

        [StringLength(30)]
        public string LL_Ten { get; set; }

        [Column(TypeName = "ntext")]
        public string LL_MoTa { get; set; }

        public double? LL_SoTienPhat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ViPham> ViPhams { get; set; }
    }
}
