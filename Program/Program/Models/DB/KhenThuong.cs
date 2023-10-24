namespace Program.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhenThuong")]
    public partial class KhenThuong
    {
        [Key]
        public int KT_Ma { get; set; }

        [Column(TypeName = "ntext")]
        public string KT_MoTa { get; set; }

        public DateTime? KT_ThoiGian { get; set; }

        public double? KT_SoTienThuong { get; set; }

        [StringLength(10)]
        public string TV_Ma { get; set; }

        public virtual ThanhVien ThanhVien { get; set; }
    }
}
