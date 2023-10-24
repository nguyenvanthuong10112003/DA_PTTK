namespace Program.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViPham")]
    public partial class ViPham
    {
        [Key]
        public int VP_Ma { get; set; }

        [Column(TypeName = "ntext")]
        public string VP_MoTa { get; set; }

        public DateTime? VP_ThoiGian { get; set; }

        [StringLength(10)]
        public string LL_Ma { get; set; }

        [StringLength(10)]
        public string TV_Ma { get; set; }

        public virtual LuatLe LuatLe { get; set; }

        public virtual ThanhVien ThanhVien { get; set; }
    }
}
