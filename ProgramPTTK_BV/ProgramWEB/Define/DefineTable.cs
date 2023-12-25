using ProgramWEB.Define.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramWEB.Define
{
    public class DefineTable
    {
        public static Table nhanSu { get; } = new Table("NhanSu",
            new string[] {
             "NS_Ma",
             "NS_HoVaTen",
             "NS_GioiTinh",
             "NS_NgaySinh",
             "NS_SoDienThoai",
             "NS_Email",
             "NS_DiaChi",
             "NS_SoCCCD",
             "NS_SoTaiKhoanNganHang",
             "NS_TenChuTaiKhoan",
             "NS_HocVan",
             "NS_NgayVao"
            },
             new string[] {
             "Mã",
             "Họ và tên",
             "Giới tính",
             "Ngày sinh",
             "Số điện thoại",
             "Email",
             "Địa chỉ",
             "Số CCCD",
             "Số tài khoản ngân hàng",
             "Tên chủ tài khoản",
             "Học vấn",
             "Ngày vào"
            },
             new bool[]
             {
                 false,
                 true,
                 true,
                 true,
                 true,
                 true,
                 true,
                 true,
                 false,
                 false,
                 false,
                 true
             }
        );
        public static Table baoHiem { get; } = new Table("BaoHiem", 
            new string[] {
             "BH_Ma",
             "BH_SoBaoHiem",
             "BH_NgayCap",
             "BH_NgayHetHan",
             "BH_NoiCap",
             "BH_NoiKhamBenh",
             "NS_Ma"
            },
             new string[] {
             "Mã",
             "Số bảo hiểm",
             "Ngày cấp",
             "Ngày hết hạn",
             "Nơi cấp",
             "Nơi khám bệnh",
             "Mã chủ bảo hiểm"
            },
             new bool[]
             {
                 false,
                 true,
                 true,
                 true,
                 true,
                 false,
                 true
             }
        );
        public static Table taiKhoan { get; } = new Table("TaiKhoan", 
            new string[] {
             "TK_TenDangNhap",
             "TK_QuyenAdmin",
             "TK_QuyenQuanLy",
             "TK_BiKhoa",
             "TK_ThoiGianMoKhoa",
             "NS_Ma"
            },
             new string[] {
             "Tên đăng nhập",
             "Quyền admin",
             "Quyền quản lý",
             "Trạng thái khóa",
             "Thời gian mở khóa",
             "Mã chủ tài khoản"
            },
             new bool[]
             {
                 true,
                 false,
                 false,
                 false,
                 false,
                 true
             }
        );
        public static Table hopDong { get; } = new Table("HopDong", 
            new string[] {
             "HD_Ma",
             "HD_NgayBatDau",
             "HD_NgayKetThuc",
             "HD_HinhThucLamViec",
             "HD_Luong",
             "HD_DonViTinhuong",
             "HD_CongViec",
             "NS_Ma"
            },
             new string[] {
             "Mã",
             "Ngày bắt đầu",
             "Ngày kết thúc",
             "Hình thức làm việc",
             "Lương",
             "Đơn vị tính lương",
             "Công việc",
             "Mã người ký hợp đồng"
            },
             new bool[]
             {
                 false,
                 true,
                 false,
                 true,
                 true,
                 true,
                 true,
                 true
             }
        );
        public static Table lichSuLamViec { get; } = new Table("LichSuLamViec", 
            new string[] {
             "LSLV_Ma",
             "LSLV_NgayBatDau",
             "LSLV_NgayKetThuc",
             "LSLV_ChucVu",
             "NS_Ma",
             "BP_Ma"
            },
            new string[] {
             "Mã",
             "Ngày bắt đầu",
             "Ngày kết thúc",
             "Chức vụ",
             "Mã nhân sự",
             "Mã bộ phận làm việc"
            },
            new bool[]
            {
                false,
                true,
                false,
                true,
                true,
                false
            }
        );
        public static Table chamCong { get; } = new Table("ChamCong", 
            new string[] {
             "CC_Ma",
             "CC_ThoiGianDen",
             "CC_ThoiGianVe",
             "CC_Ngay",
             "NS_Ma"
            },
             new string[] {
             "Mã",
             "Thời gian đến",
             "Thời gian về",
             "Ngày chấm công",
             "Mã nhân sự"
            },
             new bool[]
             {
                 false,
                 true,
                 false,
                 true,
                 true
             }
        );
        public static Table khenThuongKyLuat { get; } = new Table("KhenThuongKyLuat", 
            new string[] {
             "KTKL_Ma",
             "KTKL_MoTa",
             "KTKL_ThoiGian",
             "KTKL_HinhThuc",
             "KTKL_SoTien",
             "NS_Ma"
            },
             new string[] {
             "Mã",
             "Mô tả",
             "Thời gian",
             "Hình thức",
             "Số tiền",
             "Mã nhân sự"
            },
             new bool[]
             {
                 false,
                 false,
                 false,
                 true,
                 true,
                 true
             }
        );
        public static Table phongBan { get; } = new Table("PhongBan", 
            new string[] {
             "PB_Ma",
             "PB_Ten",
             "PB_VaiTro",
             "NS_Ma"
            },
            new string[] {
             "Mã",
             "Tên phòng ban",
             "Vai trò",
             "Mã trưởng phòng"
            },
            new bool[]
            {
                false,
                true,
                false,
                false
            }
        );
        public static Table boPhan { get; } = new Table("BoPhan", 
            new string[] {
             "BP_Ma",
             "BP_Ten",
             "BP_ChuyenMon",
             "PB_Ma",
             "NS_Ma"
            },
            new string[] {
             "Mã",
             "Tên bộ phận",
             "Chuyên môn",
             "Mã phòng ban",
             "Mã nhân sự"
            },
            new bool[]
            {
                false,
                true,
                false,
                true,
                false
            }
        );
        public static Table caLam { get; } = new Table("CaLam", 
            new string[] {
             "CL_Ma",
             "CL_TenCa",
             "CL_GioBatDau",
             "CL_PhutBatDau",
             "CL_GioKetThuc",
             "CL_PhutKetThuc"
            },
            new string[] {
             "Mã",
             "Tên ca",
             "Giờ bắt đầu",
             "Phút bắt đầu",
             "Giờ kết thúc",
             "Phút kết thúc"
            },
            new bool[]
            {
                false,
                true,
                true,
                true,
                true,
                true
            }
        );
        public static Table ngayNghi { get; } = new Table("NgayNghi",
            new string[] {
             "NN_Ma",
             "NN_Ngay",
             "NN_GhiChu"
            },
            new string[] {
             "Mã",
             "Ngày nghỉ",
             "Ghi chú"
            },
            new bool[]
            {
                false,
                true,
                false
            }
        );
        public static Table dangKyCaLam { get; } = new Table("DangKyCaLam",
            new string[] {
            "DKCL_Ma",
            "DKCL_Ngay",
            "DKCL_ThoiGianDangKy",
            "DKCL_DaDuocDuyet",
            "NS_Ma",
            "CL_Ma",
            "DDK_Ma"
            },
            new string[] {
            "Mã",
            "Ngày làm",
            "Thời gian đăng ký",
            "Trạng thái duyệt",
            "Mã người đăng ký",
            "Mã ca làm",
            "Mã duyệt đăng ký"
            },
            new bool[]
            {
                false,
                true,
                false,
                true,
                true,
                true,
                false
            }
        );
        public static Table dangKyNghiLam { get; } = new Table("DangKyNghiLam",
            new string[] {
             "DKNL_Ma",
             "DKNL_Ngay",
             "DKNL_ThoiGianDangKy",
             "DKNL_NghiCoPhep",
             "DKNL_LyDoNghi",
             "DKNL_DaDuocDuyet",
             "NS_Ma",
             "DDK_Ma"
            },
            new string[] {
             "Mã",
             "Ngày nghỉ",
             "Thời gian đăng ký",
             "Nghỉ có phép",
             "Lý do nghỉ",
             "Trạng thái duyệt",
             "Mã người đăng ký",
             "Mã duyệt đăng ký"
            },
            new bool[]
            {
                false,
                true,
                false,
                true,
                false,
                true,
                true,
                false
            }
        );
        public static Table duyetDangKy { get; } = new Table("DuyetDangKy",
            new string[] {
             "DDK_Ma",
             "DDK_ThoiGian",
             "NS_Ma"
            },
            new string[] {
             "Mã",
             "Thời gian duyệt",
             "Mã người duyệt"
            },
            new bool[]
            {
                false,
                false,
                false
            }
        );
    }
}