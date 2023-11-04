using Program.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Program.Define
{
    public class DefinePage
    {
        public static Page home { get; } = new Page("Home", "/Home/Index");
        public static Page start { get; } = new Page("Start", "/Home/Start");
        public static Page user { get; } = new Page("User", "/User/Index");
        public static Page user_ChangePassword { get; } = new Page("Change Password", "/User/ChangePassword");
        public static Page user_ForgetPassword { get; } = new Page("Forget Password", "/User/ForgetPassword");
        public static Page user_Authentication { get; } = new Page("Authentication", "/User/Authentication");
        public static Page user_Login { get; } = new Page("Login", "/User/Login");
        public static Page user_Profile { get; } = new Page("Profile", "/User/Profile");
        public static Page user_Register { get; } = new Page("Register", "/User/Register");
        public static Page management { get; } = new Page("Management", "/Management/Index");
        public static Page management_ThanhVien { get; } = new Page("ThanhVien", "/Management/ThanhVien");
        public static Page management_PhongBan { get; } = new Page("ThanhVien", "/Management/PhongBan");
        public static Page management_BoPhan { get; } = new Page("ThanhVien", "/Management/BoPhan");
        public static Page management_CongViec { get; } = new Page("ThanhVien", "/Management/CongViec");
        public static Page management_Luong { get; } = new Page("ThanhVien", "/Management/Luong");
        public static Page management_HoaDon { get; } = new Page("ThanhVien", "/Management/HoaDon");
        public static Page management_ViPham { get; } = new Page("ThanhVien", "/Management/ViPham");
        public static Page management_KhenThuong { get; } = new Page("ThanhVien", "/Management/KhenThuong");

    }
}