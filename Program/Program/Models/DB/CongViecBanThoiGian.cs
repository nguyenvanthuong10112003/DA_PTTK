namespace Program.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CongViecBanThoiGian")]
    public partial class CongViecBanThoiGian
    {
        [Key]
        [StringLength(10)]
        public string CV_Ma { get; set; }

        [Column(TypeName = "ntext")]
        public string CVBTG_MoTa { get; set; }

        public double? CVBTG_LuongTheoGio { get; set; }

        public virtual CongViec CongViec { get; set; }
    }
}
