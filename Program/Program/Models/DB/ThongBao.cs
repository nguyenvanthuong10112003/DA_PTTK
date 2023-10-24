namespace Program.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongBao")]
    public partial class ThongBao
    {
        [Key]
        [StringLength(10)]
        public string TB_Ma { get; set; }

        [StringLength(50)]
        public string TB_TieuDe { get; set; }

        [Column(TypeName = "ntext")]
        public string TB_NoiDung { get; set; }

        public DateTime? TB_ThoiGian { get; set; }

        public bool? TB_DaXem { get; set; }

        [StringLength(10)]
        public string TV_Ma { get; set; }

        [StringLength(10)]
        public string GY_Ma { get; set; }

        [StringLength(10)]
        public string HD_Ma { get; set; }

        public virtual GopY GopY { get; set; }

        public virtual HanhDong HanhDong { get; set; }

        public virtual ThanhVien ThanhVien { get; set; }
    }
}
