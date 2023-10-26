using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Program.Models
{
    public class ActionNotice
    {
        public string message { get; set; } 
        public bool isSuccess { get; set; } = false;

        public ActionNotice() {
            message = "";
            isSuccess = false;
        }

        public ActionNotice(string message, bool isSuccess) { 
            this.message = message;
            this.isSuccess = isSuccess;
        }
    }
}