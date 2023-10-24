namespace Program.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TongKetLuong")]
    public partial class TongKetLuong
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short TKL_Nam { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte TKL_Thang { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string TV_Ma { get; set; }

        public bool? TKL_TrangThaiThanhToan { get; set; }

        public double? TKL_TongSoTien { get; set; }

        [StringLength(10)]
        public string HD_Ma { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual ThanhVien ThanhVien { get; set; }
    }
}
