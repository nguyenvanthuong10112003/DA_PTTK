using PagedList;
using ProgramWEB.Define;
using ProgramWEB.Libary;
using ProgramWEB.Models.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgramWEB.Models.Object
{
    public class User
    {
        public string username { set; get; }
        public long maNhanSu { set; get; }
        public bool quyenAdmin { set; get; }
        public bool quyenQuanLy { set; get; }
        public string avatar { set; get; }
        protected QuanLyNhanSuContext context { get; set; }
        public User() { init(); }
        public User(string username, long maNhanSu, bool quyenAdmin, bool quyenQuanLy, string avatar)
        {
            this.username = username;
            this.maNhanSu = maNhanSu;
            this.quyenAdmin = quyenAdmin;
            this.quyenQuanLy = quyenQuanLy;
            this.avatar = avatar;
            init();
        }
        private void init()
        {
            if (context == null)
                context = new QuanLyNhanSuContext();
        }
        public static string login(string username, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    return DefineError.loiDuLieuKhongHopLe;
                Data.TaiKhoan taiKhoan = new QuanLyNhanSuContext().TaiKhoans.Find(username);
                if (taiKhoan == null)
                    return "Tài khoản không tồn tại.";
                if (!BCrypt.Net.BCrypt.Verify(password, taiKhoan.TK_MatKhau))
                    return "Mật khẩu đăng nhập không chính xác.";
                if (kiemTraBiKhoaVaMoKhoa(taiKhoan.TK_TenDangNhap)) 
                    return taiKhoan.TK_ThoiGianMoKhoa != null ? "Tài khoản đang bị khóa, hãy chờ đến " +
                        taiKhoan.TK_ThoiGianMoKhoa.ToString() + "." : "Tài khoản của bạn đã bị khóa vĩnh viễn.";
                return string.Empty;
            } catch { }
            return DefineError.loiHeThong;
        }
        public static bool kiemTraBiKhoaVaMoKhoa(string username)
        {
            if (string.IsNullOrEmpty(username))
                return true;
            QuanLyNhanSuContext con = new QuanLyNhanSuContext();
            Data.TaiKhoan taiKhoan = con.TaiKhoans.Find(username);
            if (taiKhoan == null)
                return true;
            if (taiKhoan.TK_BiKhoa == false)
                return false;
            if (taiKhoan.TK_ThoiGianMoKhoa == null || taiKhoan.TK_ThoiGianMoKhoa > DateTime.Now)
                return true;
            taiKhoan.TK_BiKhoa = !taiKhoan.TK_BiKhoa;
            int check = new QuanLyNhanSuContext().SaveChanges();
            if (check == 0)
                return true;
            return false;
        }
        public NhanSu getNhanSu()
        {
            try
            {
                Data.NhanSu nhanSuData = context.NhanSus.Where(item => item.NS_Ma == this.maNhanSu).FirstOrDefault();
                if (nhanSuData == null)
                    return null;
                NhanSu nhanSu = new NhanSu();
                Libary.Convert<NhanSu, Data.NhanSu>.ConvertObj(ref nhanSu, nhanSuData);
                return nhanSu;
            }
            catch { }
            return null;
        }
        public TaiKhoan getTaiKhoan()
        {
            try
            {
                Data.TaiKhoan data = context.TaiKhoans.Find(this.username);
                if (data == null)
                    return null;
                TaiKhoan result = new TaiKhoan();
                Libary.Convert<TaiKhoan, Data.TaiKhoan>.ConvertObj(ref result, data);
                return result;
            }
            catch { }
            return null;
        }
        public IEnumerable<BaoHiem> getBaoHiems()
        {
            try
            {
                IEnumerable<Data.BaoHiem> datas = context.BaoHiems.Where(item => item.NS_Ma == this.maNhanSu).OrderBy(item => item.BH_NgayCap);
                if (datas == null)
                    return null;
                return Libary.Convert<BaoHiem, Data.BaoHiem>.ConvertObjs(datas);
            }
            catch { }
            return null;
        }
        public IEnumerable<ChamCong> getChamCongs()
        {
            try
            {
                IEnumerable<Data.ChamCong> datas = context.ChamCongs.Where(item => item.NS_Ma == this.maNhanSu).OrderBy(item => item.CC_Ngay);
                if (datas == null)
                    return null;
                return Libary.Convert<ChamCong, Data.ChamCong>.ConvertObjs(datas);
            }
            catch { }
            return null;
        } 
        public IEnumerable<KhenThuongKyLuat> getKhenThuongKyLuats()
        {
            try
            {
                IEnumerable<Data.KhenThuongKyLuat> datas = context.KhenThuongKyLuats.Where(item => item.NS_Ma == this.maNhanSu).OrderBy(item => item.KTKL_HinhThuc);
                if (datas == null)
                    return null;
                return Libary.Convert<KhenThuongKyLuat, Data.KhenThuongKyLuat>.ConvertObjs(datas);
            }
            catch { }
            return null;
        }
        public IEnumerable<LichSuLamViec> getLichSuLamViecs()
        {
            try
            {
                IEnumerable<Data.LichSuLamViec> datas = context.LichSuLamViecs.Where(item => item.NS_Ma == this.maNhanSu).OrderBy(item => item.LSLV_NgayBatDau);
                if (datas == null)
                    return null;
                return Libary.Convert<LichSuLamViec, Data.LichSuLamViec>.ConvertObjs(datas);
            }
            catch { }
            return null;
        }
        public IEnumerable<HopDong> getHopDongs()
        {
            try
            {
                IEnumerable<Data.HopDong> datas = context.HopDongs.Where(item => item.NS_Ma == this.maNhanSu).OrderBy(item => item.HD_NgayBatDau);
                if (datas == null)
                    return null;
                return Libary.Convert<HopDong, Data.HopDong>.ConvertObjs(datas);
            }
            catch { }
            return null;
        }
        public bool thayDoiAnhDaiDien(string newUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(newUrl))
                    return false;
                Data.TaiKhoan taiKhoan = context.TaiKhoans.Find(this.username);
                if (taiKhoan == null) return false;
                taiKhoan.TK_AnhDaiDien = newUrl;
                int check = context.SaveChanges();
                if (check == 0)
                    return false;
                return true;
            } catch { }
            return false;
        }
        public string doiMatKhau(string oldPassword, string newPassword)
        {
            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword) || oldPassword.Length < 6 || newPassword.Length < 6)
                return DefineError.loiDuLieuKhongHopLe;
            if (oldPassword == newPassword)
                return "Mật khẩu mới và mật khẩu cũ không được trùng nhau";
            Data.TaiKhoan taiKhoan = context.TaiKhoans.Find(this.username);
            if (taiKhoan == null)
                return DefineError.khongTonTai;
            if (!BCrypt.Net.BCrypt.Verify(oldPassword, taiKhoan.TK_MatKhau))
                return "Mật khẩu cũ không chính xác.";
            taiKhoan.TK_MatKhau = BCrypt.Net.BCrypt.HashPassword(newPassword);
            int check = context.SaveChanges();
            if (check == 0)
                return DefineError.loiHeThong;
            return string.Empty;
        }

        public static string thayDoiMaXacThuc(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || !StringHelper.IsValidEmail(email))
                    return DefineError.loiDuLieuKhongHopLe;
                QuanLyNhanSuContext context = new QuanLyNhanSuContext();
                Data.TaiKhoan taiKhoan = context.TaiKhoans.Where(item => item.NhanSu.NS_Email == email).FirstOrDefault();
                if (taiKhoan == null)
                    return "Email của bạn không tồn tại trong hệ thống.";
                taiKhoan.TK_MaXacThuc = StringHelper.TaoMaXacThuc();
                DateTime now = DateTime.Now;
                now = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0);
                taiKhoan.TK_ThoiGianTaoMa = now;
                int check = context.SaveChanges();
                if (check == 0)
                    return DefineError.loiHeThong;
                return string.Empty;
            } catch { }
            return DefineError.loiHeThong;
        }

        public static string kiemTraMaXacThuc(string email, string maXacThuc)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || 
                    !StringHelper.IsValidEmail(email) || 
                    string.IsNullOrEmpty(maXacThuc) || 
                    maXacThuc.Length != 6 ||
                    maXacThuc.Where(item => item > '9' || item < '0').Count() > 1)
                    return DefineError.loiDuLieuKhongHopLe;
                QuanLyNhanSuContext context = new QuanLyNhanSuContext();
                Data.TaiKhoan taiKhoan = context.TaiKhoans.Where(item => item.NhanSu.NS_Email == email).FirstOrDefault();
                if (taiKhoan == null)
                    return "Email của bạn không tồn tại trong hệ thống.";
                if (taiKhoan.TK_MaXacThuc != maXacThuc)
                    return "Mã xác thực không chính xác";
                if (taiKhoan.TK_ThoiGianTaoMa.Value.AddMinutes(5) < DateTime.Now)
                    return "Mã xác thực này đã hết hạn sử dụng. Vui lòng gửi lại mã xác thực khác.";
                return string.Empty;
            }
            catch { }
            return DefineError.loiHeThong;
        }

        public IEnumerable<NgayNghi> getNgayNghis(int year = 1, int month = 1)
        {
            try
            {
                if (year < 0 || month < 0 || month > 12)
                {
                    year = DateTime.Now.Year;
                    month = DateTime.Now.Month;
                }
                return Convert<NgayNghi, Data.NgayNghi>.ConvertObjs(context.NgayNghis
                    .Where(item => item.NN_Ngay.Year == year && item.NN_Ngay.Month == month).OrderBy(item => item.NN_Ngay));
            } catch { }
            return null;
        }
        public IEnumerable<CaLam> getCaLams()
        {
            try
            {
                Data.HopDong hopDong = context.HopDongs.Where(item => item.NS_Ma == this.maNhanSu && item.HD_HinhThucLamViec.Contains("PartTime")
                                        && item.HD_NgayBatDau < DateTime.Now && (item.HD_NgayKetThuc == null || item.HD_NgayKetThuc > DateTime.Now))
                                            .OrderByDescending(item => item.HD_NgayBatDau).FirstOrDefault();
                if (hopDong == null)
                    return null;
                return Convert<CaLam, Data.CaLam>.ConvertObjs(context.CaLams.OrderBy(item => item.CL_TenCa));
            }
            catch { }
            return null;
        }

        public IEnumerable<DangKyNghiLam> getDangKyNghiLams(int year = 1, int month = 1)
        {
            try
            {
                if (year < 0 || month < 0 || month > 12)
                {
                    year = DateTime.Now.Year;
                    month = DateTime.Now.Month;
                }
                return Convert<DangKyNghiLam, Data.DangKyNghiLam>.ConvertObjs(context.DangKyNghiLams
                    .Where(item => (item.NS_Ma == this.maNhanSu && item.DKNL_Ngay.Year == year && item.DKNL_Ngay.Month == month)).OrderBy(item => item.DKNL_Ngay));
            }
            catch { }
            return null;
        }
        public IEnumerable<DangKyCaLam> getDangKyCaLams(int year = 1, int month = 1)
        {
            try
            {
                if (year < 0 || month < 0 || month > 12)
                {
                    year = DateTime.Now.Year;
                    month = DateTime.Now.Month;
                }
                return Convert<DangKyCaLam, Data.DangKyCaLam>.ConvertObjs(context.DangKyCaLams
                    .Where(item => (item.NS_Ma == this.maNhanSu && item.DKCL_Ngay.Year == year && item.DKCL_Ngay.Month == month)).OrderBy(item => item.DKCL_Ngay));
            }
            catch { }
            return null;
        }
//Duyet dang ky
        public int demDuyetDangKy()
        {
            try
            {
                return context.DuyetDangKies.Count();
            }
            catch { }
            return 0;
        }
        public IEnumerable<Object.DuyetDangKy> layDanhSachDuyetDangKy()
        {
            try
            {

                if (context != null)
                    return Convert<Object.DuyetDangKy, Data.DuyetDangKy>.ConvertObjs(context.DuyetDangKies);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public List<IEnumerable<Object.DuyetDangKy>> layDanhSachDuyetDangKy(Object.DuyetDangKy findBy = null, int page = 1, int pageSize = 10, string sortBy = "DDK_Ma", bool sortTangDan = true)
        {
            try
            {

                IEnumerable<Object.DuyetDangKy> results =
                    (findBy != null ? timKiemNhieuDuyetDangKy(findBy)
                    : Convert<Object.DuyetDangKy, Data.DuyetDangKy>.ConvertObjs(from DuyetDangKy in context.DuyetDangKies select DuyetDangKy));
                if (results == null)
                    return new List<IEnumerable<Object.DuyetDangKy>>()
                    {
                        new List<Object.DuyetDangKy>(),
                        new List<Object.DuyetDangKy>()
                    };
                results = ObjectHelper.OrderByDynamic<Object.DuyetDangKy>(results, sortBy, sortTangDan ? "asc" : "desc");
                int p = results.Count();
                if (p == 0)
                    return new List<IEnumerable<Object.DuyetDangKy>>()
                    {
                        new List<Object.DuyetDangKy>(),
                        new List<Object.DuyetDangKy>()
                    };
                else
                    pageSize = pageSize < p ? pageSize : p;
                p = (p % pageSize) == 0 ? (p / pageSize) : (p / pageSize + 1);
                page = page > p ? p : page <= 0 ? 1 : page;
                return new List<IEnumerable<Object.DuyetDangKy>>()
                {
                    results,
                    results.Count() > pageSize ? results.ToPagedList(page, pageSize) : results
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public IEnumerable<Object.DuyetDangKy> timKiemNhieuDuyetDangKy(Object.DuyetDangKy find = null)
        {
            try
            {
                if (find != null)
                {
                    return Convert<Object.DuyetDangKy, Data.DuyetDangKy>.ConvertObjs(from DuyetDangKy in context.DuyetDangKies
                                                                                     where
                                                                                     (find.DDK_Ma != null ? DuyetDangKy.DDK_Ma == find.DDK_Ma : DuyetDangKy != null) &&
                                                                                     (find.DDK_ThoiGian != null ? DuyetDangKy.DDK_ThoiGian == find.DDK_ThoiGian : DuyetDangKy != null) &&
                                                                                     (find.NS_Ma != null ? DuyetDangKy.NS_Ma == find.NS_Ma : DuyetDangKy != null)
                                                                                     select DuyetDangKy);
                }
                return Convert<Object.DuyetDangKy, Data.DuyetDangKy>.ConvertObjs(context.DuyetDangKies);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public Object.DuyetDangKy timKiemMotDuyetDangKy(long ma)
        {
            try
            {
                if (ma <= 0)
                    return null;
                Object.DuyetDangKy convert = new DuyetDangKy();
                Convert<Object.DuyetDangKy, Data.DuyetDangKy>.ConvertObj(ref convert, context.DuyetDangKies.Find(ma));
                return convert;
            }
            catch { }
            return null;
        }
        public string huyDangKyNghiLam(int? year, int? month, int? day)
        {
            try
            {
                if (day == null || day < 1 || day > 31 || month == null || month < 1 || month > 12 || year == null || year < 1)
                    return DefineError.loiDuLieuKhongHopLe;
                Data.DangKyNghiLam dangKy = context.DangKyNghiLams.Where(item => item.NS_Ma == this.maNhanSu && item.DKNL_Ngay.Day == day && item.DKNL_Ngay.Month == month &&
                                            item.DKNL_Ngay.Year == year).FirstOrDefault();
                if (dangKy == null)
                    return DefineError.khongTonTai;
                if (dangKy.DKNL_DaDuocDuyet)
                    return "Không thể hủy khi đã được duyệt";
                context.DangKyNghiLams.Remove(dangKy);
                int check = context.SaveChanges();
                if (check == 0)
                    return DefineError.loiHeThong;
                return string.Empty;
            } catch { }
            return DefineError.loiHeThong;
        }
        public string dangKyNghiLam(Object.DangKyNghiLam newDangKy)
        {
            try
            {
                if (newDangKy == null || newDangKy.DKNL_Ngay == null || newDangKy.NS_Ma <= 0 || newDangKy.DKNL_Ngay <= DateTime.Now)
                    return DefineError.loiDuLieuKhongHopLe;
                if (context.NgayNghis.Where(item => item.NN_Ngay == newDangKy.DKNL_Ngay).FirstOrDefault() != null)
                    return "Ngày này là ngày nghỉ rồi";
                Data.DangKyNghiLam dangKy = context.DangKyNghiLams.Where(item => item.NS_Ma == this.maNhanSu && item.DKNL_Ngay == newDangKy.DKNL_Ngay).FirstOrDefault();
                if (dangKy != null)
                    return DefineError.daTonTai;
                dangKy = new Data.DangKyNghiLam();
                Convert<Data.DangKyNghiLam, Object.DangKyNghiLam>.ConvertObj(ref dangKy, newDangKy);
                dangKy.DKNL_ThoiGianDangKy = DateTime.Now;
                dangKy.NS_Ma = this.maNhanSu;
                context.DangKyNghiLams.Add(dangKy);
                int check = context.SaveChanges();
                if (check == 0)
                    return DefineError.loiHeThong;
                return string.Empty;
            }
            catch { }
            return DefineError.loiHeThong;
        }
        public void dangKyCaLam(int ?day, int ?month, int?year, long[]arrMa)
        {
            try
            {
                if (day == null || day < 0 || day > 31 || arrMa == null || arrMa.Length == 0 || month < 1 || month > 12 || year == null || year < 1 || month == null)
                    return;
                if (day <= DateTime.Now.Day)
                    return;
                Data.HopDong hopDong = context.HopDongs.Where(item => item.NS_Ma == this.maNhanSu && item.HD_HinhThucLamViec.Contains("PartTime")
                        && item.HD_NgayBatDau < DateTime.Now && (item.HD_NgayKetThuc == null || item.HD_NgayKetThuc > DateTime.Now))
                            .OrderByDescending(item => item.HD_NgayBatDau).FirstOrDefault();
                if (hopDong == null)
                    return;
                foreach (var item in arrMa)
                {
                    Data.CaLam caLam = context.CaLams.Find(item);
                    if (caLam == null) continue;
                    Data.DangKyCaLam dangKyCaLam = context.DangKyCaLams.Where(item1 => item1.NS_Ma == this.maNhanSu &&
                                                        item1.DKCL_Ngay.Day == day && item1.DKCL_Ngay.Month == month && item1.DKCL_Ngay.Year == year
                                                        && item1.CL_Ma == item).FirstOrDefault();
                    if (dangKyCaLam != null)
                    {
                        continue;
                    }
                    dangKyCaLam = new Data.DangKyCaLam();
                    dangKyCaLam.CL_Ma = item;
                    dangKyCaLam.NS_Ma = this.maNhanSu;
                    dangKyCaLam.DKCL_ThoiGianDangKy = DateTime.Now;
                    dangKyCaLam.DKCL_Ngay = new DateTime(year.Value, month.Value, day.Value);
                    if (context.NgayNghis.Where(item1 => item1.NN_Ngay == dangKyCaLam.DKCL_Ngay).FirstOrDefault() != null)
                        continue;
                    if (context.DangKyNghiLams.Where(item1 => item1.DKNL_Ngay == dangKyCaLam.DKCL_Ngay && item1.DKNL_DaDuocDuyet == true && item1.NS_Ma == this.maNhanSu).FirstOrDefault() != null)
                        continue;
                    context.DangKyCaLams.Add(dangKyCaLam);
                }
                context.SaveChanges();
            } catch { }
        }
        public void huyDangKyCaLam(int? day, int? month, int? year, long[] arrMa)
        {
            try
            {
                if (day == null || day < 0 || day > 31 || arrMa == null || arrMa.Length == 0 || month < 1 || month > 12 || year == null || year < 1 || month == null)
                    return;
                if (day <= DateTime.Now.Day)
                    return;
                Data.HopDong hopDong = context.HopDongs.Where(item => item.NS_Ma == this.maNhanSu && item.HD_HinhThucLamViec.Contains("PartTime")
                        && item.HD_NgayBatDau < DateTime.Now && (item.HD_NgayKetThuc == null || item.HD_NgayKetThuc > DateTime.Now))
                            .OrderByDescending(item => item.HD_NgayBatDau).FirstOrDefault();
                if (hopDong == null)
                    return;
                foreach (var item in arrMa)
                {
                    Data.DangKyCaLam dangKyCaLam = context.DangKyCaLams.Where(item1 => item1.NS_Ma == this.maNhanSu &&
                                                        item1.DKCL_Ngay.Day == day && item1.DKCL_Ngay.Month == month && item1.DKCL_Ngay.Year == year
                                                        && item1.CL_Ma == item).FirstOrDefault();
                    if (dangKyCaLam == null)
                    {
                        continue;
                    }
                    if (dangKyCaLam.DKCL_DaDuocDuyet)
                        continue;
                    context.DangKyCaLams.Remove(dangKyCaLam);
                }
                context.SaveChanges();
            }
            catch { }
        }
    }
}