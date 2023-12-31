﻿using ProgramWEB.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgramWEB.Models.Object
{
    public class LichSuLamViec
    {
        public long? LSLV_Ma { get; set; }
        public DateTime? LSLV_NgayBatDau { get; set; }
        public DateTime? LSLV_NgayKetThuc { get; set; }
        public string LSLV_ChucVu { get; set; }
        public long? NS_Ma { get; set; }
        public long? BP_Ma { get; set; }
        public LichSuLamViec()
        {
            this.LSLV_Ma = null;
            this.LSLV_NgayBatDau = null;
            this.LSLV_NgayKetThuc = null;
            this.LSLV_ChucVu = string.Empty;
            this.NS_Ma = null;
            this.BP_Ma = null;
        }
    }
}