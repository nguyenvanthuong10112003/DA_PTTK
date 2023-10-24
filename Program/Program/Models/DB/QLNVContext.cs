using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Program.Models.DB
{
    public partial class QLNVContext : DbContext
    {
        public QLNVContext()
            : base("name=QLNVContext2")
        {
        }

        public virtual DbSet<BaoHiem> BaoHiems { get; set; }
        public virtual DbSet<BoPhan> BoPhans { get; set; }
        public virtual DbSet<ChamCong> ChamCongs { get; set; }
        public virtual DbSet<CongViec> CongViecs { get; set; }
        public virtual DbSet<CongViecBanThoiGian> CongViecBanThoiGians { get; set; }
        public virtual DbSet<CongViecDaLam> CongViecDaLams { get; set; }
        public virtual DbSet<GopY> Gopies { get; set; }
        public virtual DbSet<HanhDong> HanhDongs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhenThuong> KhenThuongs { get; set; }
        public virtual DbSet<LuatLe> LuatLes { get; set; }
        public virtual DbSet<NganHang> NganHangs { get; set; }
        public virtual DbSet<NghiLam> NghiLams { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ThanhVien> ThanhViens { get; set; }
        public virtual DbSet<ThongBao> ThongBaos { get; set; }
        public virtual DbSet<TongKetLuong> TongKetLuongs { get; set; }
        public virtual DbSet<ViPham> ViPhams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaoHiem>()
                .Property(e => e.BH_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BaoHiem>()
                .Property(e => e.TV_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BoPhan>()
                .Property(e => e.BP_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BoPhan>()
                .Property(e => e.PB_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BoPhan>()
                .Property(e => e.TV_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ChamCong>()
                .Property(e => e.CVDL_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CongViec>()
                .Property(e => e.CV_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CongViec>()
                .HasOptional(e => e.CongViecBanThoiGian)
                .WithRequired(e => e.CongViec)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CongViecBanThoiGian>()
                .Property(e => e.CV_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CongViecDaLam>()
                .Property(e => e.CVDL_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CongViecDaLam>()
                .Property(e => e.CV_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CongViecDaLam>()
                .Property(e => e.BP_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CongViecDaLam>()
                .Property(e => e.TV_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GopY>()
                .Property(e => e.GY_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GopY>()
                .Property(e => e.TV_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HanhDong>()
                .Property(e => e.HD_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HanhDong>()
                .Property(e => e.TV_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.HD_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KhenThuong>()
                .Property(e => e.TV_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LuatLe>()
                .Property(e => e.LL_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LuatLe>()
                .HasMany(e => e.ViPhams)
                .WithOptional(e => e.LuatLe)
                .WillCascadeOnDelete();

            modelBuilder.Entity<NganHang>()
                .Property(e => e.NH_SoTaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<NganHang>()
                .Property(e => e.NH_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NganHang>()
                .Property(e => e.NH_TenChuTaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<NganHang>()
                .Property(e => e.TV_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NghiLam>()
                .Property(e => e.CVDL_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhongBan>()
                .Property(e => e.PB_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhongBan>()
                .Property(e => e.TV_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhongBan>()
                .HasMany(e => e.BoPhans)
                .WithOptional(e => e.PhongBan)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Quyen>()
                .Property(e => e.TK_TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TK_TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TK_MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TK_MaXacThuc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TK_MaBaoVe)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasOptional(e => e.Quyen)
                .WithRequired(e => e.TaiKhoan)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ThanhVien>()
                .Property(e => e.TV_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ThanhVien>()
                .Property(e => e.TV_SoDienThoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ThanhVien>()
                .Property(e => e.TV_Email)
                .IsUnicode(false);

            modelBuilder.Entity<ThanhVien>()
                .Property(e => e.TV_SoCCCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ThanhVien>()
                .Property(e => e.TK_TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<ThanhVien>()
                .HasMany(e => e.BaoHiems)
                .WithOptional(e => e.ThanhVien)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ThanhVien>()
                .HasMany(e => e.CongViecDaLams)
                .WithOptional(e => e.ThanhVien)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ThanhVien>()
                .HasMany(e => e.KhenThuongs)
                .WithOptional(e => e.ThanhVien)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ThanhVien>()
                .HasMany(e => e.NganHangs)
                .WithOptional(e => e.ThanhVien)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ThongBao>()
                .Property(e => e.TB_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ThongBao>()
                .Property(e => e.TV_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ThongBao>()
                .Property(e => e.GY_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ThongBao>()
                .Property(e => e.HD_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TongKetLuong>()
                .Property(e => e.TV_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TongKetLuong>()
                .Property(e => e.HD_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ViPham>()
                .Property(e => e.LL_Ma)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ViPham>()
                .Property(e => e.TV_Ma)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
