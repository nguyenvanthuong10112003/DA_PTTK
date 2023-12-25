namespace ProgramWEB.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichSuLamViec")]
    public partial class LichSuLamViec
    {
        [Key]
        public long LSLV_Ma { get; set; }

        [Column(TypeName = "date")]
        public DateTime LSLV_NgayBatDau { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LSLV_NgayKetThuc { get; set; }

        [Required]
        [StringLength(50)]
        public string LSLV_ChucVu { get; set; }

        public long NS_Ma { get; set; }

        public long? BP_Ma { get; set; }

        public virtual BoPhan BoPhan { get; set; }

        public virtual NhanSu NhanSu { get; set; }
    }
}
