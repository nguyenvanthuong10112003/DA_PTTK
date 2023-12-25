using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgramWEB.Models.Object
{
    public class BoPhan
    {
        public long? BP_Ma { get; set; }
        public string BP_Ten { get; set; }
        public string BP_ChuyenMon { get; set; }
        public long? PB_Ma { get; set; }
        public long? NS_Ma { get; set; }
        public BoPhan()
        {
            this.PB_Ma = null;
            this.BP_Ten = string.Empty;
            this.BP_ChuyenMon = string.Empty;
            this.PB_Ma = null;
            this.NS_Ma = null;
        }
    }
}