namespace Program.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChamCong")]
    public partial class ChamCong
    {
        [Key]
        [Column(Order = 0, TypeName = "date")]
        public DateTime CC_Ngay { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string CVDL_Ma { get; set; }

        public DateTime CC_ThoiGianDen { get; set; }

        public DateTime? CC_ThoiGianVe { get; set; }

        public virtual CongViecDaLam CongViecDaLam { get; set; }
    }
}
