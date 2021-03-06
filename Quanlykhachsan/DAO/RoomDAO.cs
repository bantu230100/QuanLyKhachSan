﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public class RoomDAO
    {
        static QUAN_LY_KHACH_SANEntities context = new QUAN_LY_KHACH_SANEntities();

        //111111111111111111111
        public static List<RoomDTO> LayMaPhongLoaiPhong()
        {
            var query = (from r in context.PHONGs
                         join t in context.LOAI_PHONG on r.LOAI_PHONG.MaLoaiPhong equals t.MaLoaiPhong
                         where r.TinhTrang == "Trống"
                         select new RoomDTO
                         {
                             MaPhong = r.MaPhong,
                             TenLoaiPhong = r.LOAI_PHONG.TenLoaiPhong,
                             GhiChu = r.GhiChu,
                             DonGia = r.LOAI_PHONG.DonGia,

                         }).OrderBy(r => r.TenLoaiPhong);
            return query.ToList();
        }


        //22222222222
        public static int LaySLPhongTrongTheoLoai(string lp)
        {
            int num = (from r in context.PHONGs
                       join t in context.LOAI_PHONG on r.LOAI_PHONG.MaLoaiPhong equals t.MaLoaiPhong
                       where r.LOAI_PHONG.MaLoaiPhong == lp && r.TinhTrang == "Trống"
                       select new RoomDTO
                       {
                       }).Count();
            return num;
        }

        public static List<PhieuThuePhongDTO> DanhSachPhongDangDuocThue()
        {
            var query = (from p in context.PHIEU_THUE_PHONG
                         select new PhieuThuePhongDTO
                         {
                             MaPhong = p.MaPhong,
                         });
            return query.ToList();
        }

        public static List<RoomDTO> LoadDonGia(string text)
        {
            var query = (from t in context.LOAI_PHONG

                         where t.TenLoaiPhong == text
                         select new RoomDTO
                         {
                             DonGia = t.DonGia,
                         });
            return query.ToList();
        }

        public static bool SuaThongTinPhong(RoomDTO infor)
        {
            SqlParameter maphong = new SqlParameter("@MaPhong", infor.MaPhong);
            SqlParameter tinhtrang = new SqlParameter("@TinhTrang", infor.TinhTrang);
            SqlParameter malp = new SqlParameter("@MaLoaiPhong", infor.MaLoaiPhong);
            SqlParameter ghichu = new SqlParameter("@GhiChu", infor.GhiChu);

            try
            {
                context.Database.ExecuteSqlCommand("spSuaThongTinPhong @MaPhong, @TinhTrang, @MaLoaiPhong, @GhiChu",
                                    maphong, tinhtrang, malp, ghichu);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<RoomDTO> DanhSachPhongTheoDGTu(decimal dgtu)
        {
            var query = (from r in context.PHONGs
                         join t in context.LOAI_PHONG on r.LOAI_PHONG.MaLoaiPhong equals t.MaLoaiPhong
                         where t.DonGia >= dgtu
                         select new RoomDTO
                         {
                             MaPhong = r.MaPhong,
                             TinhTrang = r.TinhTrang,
                             GhiChu = r.GhiChu,
                             TenLoaiPhong = r.LOAI_PHONG.TenLoaiPhong,
                             DonGia = r.LOAI_PHONG.DonGia,
                         }).OrderByDescending(s => s.TinhTrang);
            return query.ToList();
        }

        public static object DanhSachPhongTraGanNhat()
        {
            var query = (from t in context.LOAI_PHONG
                         join r in context.PHONGs on t.MaLoaiPhong equals r.MaLoaiPhong
                         join f in context.PHIEU_THUE_PHONG on r.MaPhong equals f.MaPhong
                         select new RoomDTO
                         {
                             MaPhong = r.MaPhong,
                             TinhTrang = r.TinhTrang,
                             GhiChu = r.GhiChu,
                             TenLoaiPhong = r.LOAI_PHONG.TenLoaiPhong,
                             DonGia = r.LOAI_PHONG.DonGia,
                             NgayTraPhongDK = f.NgayTraPhongDK,
                         }).OrderByDescending(s => s.NgayTraPhongDK);
            return query.ToList();
        }

        public static bool XoaPhongTrongCTHoaDon(RoomDTO infor)
        {
            SqlParameter maphong = new SqlParameter("@MaPhong", infor.MaPhong);
            try
            {
                context.Database.ExecuteSqlCommand("spXoaPhongTrongCTHoaDon @MaPhong", maphong);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static List<PhieuThuePhongDTO> NgayTraPhong()
        {
            var query = (from r in context.PHIEU_THUE_PHONG
                         select new PhieuThuePhongDTO
                         {
                             NgayTraPhong = r.NgayTraPhongDK,
                             MaPhong = r.MaPhong
                         });
            return query.ToList();
        }

        public static List<RoomDTO> DanhSachPhongTheoDGDen(decimal dgden)
        {
            var query = (from r in context.PHONGs
                         join t in context.LOAI_PHONG on r.LOAI_PHONG.MaLoaiPhong equals t.MaLoaiPhong
                         where t.DonGia <= dgden
                         select new RoomDTO
                         {
                             MaPhong = r.MaPhong,
                             TinhTrang = r.TinhTrang,
                             GhiChu = r.GhiChu,
                             TenLoaiPhong = r.LOAI_PHONG.TenLoaiPhong,
                             DonGia = r.LOAI_PHONG.DonGia,
                         }).OrderByDescending(s => s.TinhTrang);
            return query.ToList();
        }

        public static List<RoomDTO> DanhSachPhongTheoKhoangDG(decimal dgtu, decimal dgden)
        {
            var query = (from r in context.PHONGs
                         join t in context.LOAI_PHONG on r.LOAI_PHONG.MaLoaiPhong equals t.MaLoaiPhong
                         where (t.DonGia >= dgtu) && (t.DonGia <= dgden)
                         select new RoomDTO
                         {
                             MaPhong = r.MaPhong,
                             TinhTrang = r.TinhTrang,
                             GhiChu = r.GhiChu,
                             TenLoaiPhong = r.LOAI_PHONG.TenLoaiPhong,
                             DonGia = r.LOAI_PHONG.DonGia,
                         }).OrderByDescending(s => s.TinhTrang);
            return query.ToList();
        }

        public static List<RoomDTO> DanhSachPhongTheoLoaiTheoYeuCau(RoomDTO thongtin)
        {
            var query = (from r in context.PHONGs
                         join t in context.LOAI_PHONG on r.LOAI_PHONG.MaLoaiPhong equals t.MaLoaiPhong
                         where (t.TenLoaiPhong == thongtin.TenLoaiPhong) && (r.GhiChu.Contains(thongtin.GhiChu))
                         select new RoomDTO
                         {
                             MaPhong = r.MaPhong,
                             TinhTrang = r.TinhTrang,
                             GhiChu = r.GhiChu,
                             TenLoaiPhong = r.LOAI_PHONG.TenLoaiPhong,
                             DonGia = r.LOAI_PHONG.DonGia,
                         }).OrderByDescending(s => s.TinhTrang);
            return query.ToList();
        }

        public static List<RoomDTO> DanhSachPhongYeuCau(RoomDTO thongtin)
        {
            var query = (from r in context.PHONGs
                         join t in context.LOAI_PHONG on r.LOAI_PHONG.MaLoaiPhong equals t.MaLoaiPhong
                         where r.GhiChu.Contains(thongtin.GhiChu)
                         select new RoomDTO
                         {
                             MaPhong = r.MaPhong,
                             TinhTrang = r.TinhTrang,
                             GhiChu = r.GhiChu,
                             TenLoaiPhong = r.LOAI_PHONG.TenLoaiPhong,
                             DonGia = r.LOAI_PHONG.DonGia,
                         }).OrderByDescending(s => s.TinhTrang);
            return query.ToList();
        }

        public static List<RoomDTO> DanhSachPhongTheoLoai(RoomDTO thongtin)
        {
            var query = (from r in context.PHONGs
                         join t in context.LOAI_PHONG on r.LOAI_PHONG.MaLoaiPhong equals t.MaLoaiPhong
                         where t.TenLoaiPhong == thongtin.TenLoaiPhong
                         select new RoomDTO
                         {
                             MaPhong = r.MaPhong,
                             TinhTrang = r.TinhTrang,
                             GhiChu = r.GhiChu,
                             TenLoaiPhong = r.LOAI_PHONG.TenLoaiPhong,
                             DonGia = r.LOAI_PHONG.DonGia,
                         }).OrderByDescending(s => s.TinhTrang);
            return query.ToList();
        }

        public static bool ThietLapTrangThaiPhongBanDau(BillDTO inforHD)
        {
            SqlParameter maphong = new SqlParameter("@MaPhong", inforHD.MaPhong);
            try
            {
                context.Database.ExecuteSqlCommand("spThietLapTTrangPhongBanDau @MaPhong", maphong);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool XoaPhong(RoomDTO infor)
        {
            SqlParameter maphong = new SqlParameter("@MaPhong", infor.MaPhong);
            try
            {
                context.Database.ExecuteSqlCommand("spXoaPhong @MaPhong", maphong);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ThemPhong(RoomDTO infor)
        {
            SqlParameter tinhtrang = new SqlParameter("@TinhTrang", infor.TinhTrang);
            SqlParameter malp = new SqlParameter("@MaLoaiPhong", infor.MaLoaiPhong);
            SqlParameter ghichu = new SqlParameter("@GhiChu", infor.GhiChu);

            try
            {
                context.Database.ExecuteSqlCommand("spThemPhongMoi @TinhTrang, @MaLoaiPhong, @GhiChu",
                                    tinhtrang, malp, ghichu);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<RoomDTO> DanhSachPhong()
        {
            var query = (from r in context.PHONGs
                         join t in context.LOAI_PHONG on r.LOAI_PHONG.MaLoaiPhong equals t.MaLoaiPhong
                         select new RoomDTO
                         {
                             MaPhong = r.MaPhong,
                             TinhTrang = r.TinhTrang,
                             GhiChu = r.GhiChu,
                             TenLoaiPhong = r.LOAI_PHONG.TenLoaiPhong,
                             DonGia = r.LOAI_PHONG.DonGia,

                         }).OrderByDescending(s => s.TinhTrang);
            return query.ToList();
        }
        public static List<RoomDTO> DanhSachPhongTK()
        {
            var query = (from t in context.LOAI_PHONG
                         join r in context.PHONGs on t.MaLoaiPhong equals r.MaLoaiPhong
                         join f in context.PHIEU_THUE_PHONG on r.MaPhong equals f.MaPhong
                         select new RoomDTO
                         {
                             MaPhong = r.MaPhong,
                             TinhTrang = r.TinhTrang,
                             GhiChu = r.GhiChu,
                             TenLoaiPhong = r.LOAI_PHONG.TenLoaiPhong,
                             DonGia = r.LOAI_PHONG.DonGia,
                             NgayTraPhongDK = f.NgayTraPhongDK,
                         }).OrderByDescending(s => s.TinhTrang);
            return query.ToList();
        }

        public static List<RoomDTO> LoaiPhong()
        {
            var query = (from t in context.LOAI_PHONG
                         select new RoomDTO
                         {
                             MaLoaiPhong = t.MaLoaiPhong,
                             TenLoaiPhong = t.TenLoaiPhong,
                         });
            return query.ToList();
        }

        //333333333333333333333
        public static List<RoomDTO> LayDanhSachLoaiPhong()
        {
            var query = (from t in context.LOAI_PHONG
                         select new RoomDTO
                         {
                             MaLoaiPhong = t.MaLoaiPhong,
                         });
            return query.ToList();
        }

        public static bool CapNhatTinhTrangPhong(PhieuThuePhongDTO p)
        {
            SqlParameter maphong = new SqlParameter("@MaPhong", p.MaPhong);
            try
            {
                context.Database.ExecuteSqlCommand("spCapNhatTinhTrangPhong @MaPhong", maphong);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<ParameDTO> SoLuongKhachToiDa()
        {
            var query = (from max in context.THAM_SO
                         select new ParameDTO
                         {
                             SLKhachToiDa = max.SoKhachToiDa,
                         });
            return query.ToList();
        }
    }
}
