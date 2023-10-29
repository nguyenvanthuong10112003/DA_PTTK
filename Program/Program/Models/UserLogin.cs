using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Program.Models
{
    public class UserLogin
    {
        public string username { get; set; }
        public string code { get; set; }

        public UserLogin(string username, string code) { 
            this.username = username;
            this.code = code;
        }
    }
}