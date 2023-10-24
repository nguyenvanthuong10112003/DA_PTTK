namespace Program.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NghiLam")]
    public partial class NghiLam
    {
        [Key]
        [Column(Order = 0, TypeName = "date")]
        public DateTime NL_Ngay { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string CVDL_Ma { get; set; }

        public bool NL_NghiCoPhep { get; set; }

        [StringLength(200)]
        public string NL_LyDoNghi { get; set; }

        public virtual CongViecDaLam CongViecDaLam { get; set; }
    }
}
