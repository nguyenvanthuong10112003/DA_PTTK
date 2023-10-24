using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Program.Models
{
    public class Account
    {
        public string username { get; set; }
        public string password { get; set; }
        public bool remember { get; set; }
        public Account() {
            username = "";
            password = "";
            remember = false;
        }
        public Account(string username, string password)
        {
            this.username = username;
            this.password = password;
            this.remember = false;
        }
        public Account(string username, string password, bool remember) { 
            this.username = username;
            this.password = password;
            this.remember = remember;   
        }
    }
}