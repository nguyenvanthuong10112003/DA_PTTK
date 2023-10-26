using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Program.Models
{
    public class Account
    {
        public string username { set; get; }
        public string password { set; get; }
        public bool remember { set; get; }
        public Account() {
            username = "";
            password = "";
            remember = false;
        }
        public Account(string username, string password)
        {
            this.username = username;
            this.password = password;
            remember = false;
        }
        public Account(string username, string password, bool remember)
        {
            this.username = username;
            this.password = password;
            this.remember = remember;
        }
    }
}