using Newtonsoft.Json;
using ProgramWEB.Define;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgramWEB.Controllers
{
    public class DangKyController : Controller
    {
        public string HuyDangKyNghiLam(int ?day, int ?month, int ?year)
        {
            try
            {
                Models.Object.User user = (Models.Object.User)Session[DefineSession.userSession];
                if (user == null)
                    return JsonConvert.SerializeObject(new { error = DefineError.canDangNhap });
                string error = user.huyDangKyNghiLam(year, month, day);
                if (!string.IsNullOrEmpty(error))
                    return JsonConvert.SerializeObject(new {error = error});
                return JsonConvert.SerializeObject(new { success = "Hủy đăng ký thành công" });
            } catch (Exception ex) { }
            return JsonConvert.SerializeObject(new {error = DefineError.loiHeThong});
        }
        public string DangKyNghiLam(Models.Object.DangKyNghiLam newDangKy)
        {
            try
            {
                Models.Object.User user = (Models.Object.User)Session[DefineSession.userSession];
                if (user == null)
                    return JsonConvert.SerializeObject(new { error = DefineError.canDangNhap });
                string error = user.dangKyNghiLam(newDangKy);
                if (!string.IsNullOrEmpty(error))
                    return JsonConvert.SerializeObject(new { error = error });
                return JsonConvert.SerializeObject(new { success = "Đăng ký thành công" });
            }
            catch (Exception ex) { }
            return JsonConvert.SerializeObject(new { error = DefineError.loiHeThong });
        }
        public string DangKyCaLam(int? day, int? month, int? year, long[] arrCL)
        {
            try
            {
                Models.Object.User user = (Models.Object.User)Session[DefineSession.userSession];
                if (user == null)
                    return JsonConvert.SerializeObject(new { error = DefineError.canDangNhap });
                user.dangKyCaLam(day, month, year, arrCL);
                return JsonConvert.SerializeObject(new { success = "Đăng ký thành công" });
            } catch { }
            return JsonConvert.SerializeObject(new { error = DefineError.loiHeThong });
        }
        public string HuyDangKyCaLam(int? day, int? month, int? year, long[] arrCL)
        {
            try
            {
                Models.Object.User user = (Models.Object.User)Session[DefineSession.userSession];
                if (user == null)
                    return JsonConvert.SerializeObject(new { error = DefineError.canDangNhap });
                user.huyDangKyCaLam(day, month, year, arrCL);
                return JsonConvert.SerializeObject(new { success = "Hủy đăng ký thành công" });
            }
            catch { }
            return JsonConvert.SerializeObject(new { error = DefineError.loiHeThong });
        }
    }
}