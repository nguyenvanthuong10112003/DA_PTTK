namespace Program.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaoHiem")]
    public partial class BaoHiem
    {
        [Key]
        [StringLength(10)]
        public string BH_Ma { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BH_NgayCap { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BH_NgayHetHan { get; set; }

        [StringLength(50)]
        public string BH_NoiCap { get; set; }

        [StringLength(10)]
        public string TV_Ma { get; set; }

        public virtual ThanhVien ThanhVien { get; set; }
    }
}
