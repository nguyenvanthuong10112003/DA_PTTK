using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Program.Models
{
    public class Account
    {
        [MaxLength(10)]
        public string code { set; get; }
        public string email { set; get; }
        public string username { set; get; }
        public string password { set; get; }
        public bool remember { set; get; }
        public bool accept { set; get; }
        public Account() {
            username = "";
            password = "";
            code = "";
            email = "";
            remember = false;
            accept = false;
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
        public Account(string code, string email, string username, string password, bool accept)
        {
            this.code = code;
            this.email = email;
            this.username = username;
            this.password = password;
            this.accept = accept;
        }
    }
}