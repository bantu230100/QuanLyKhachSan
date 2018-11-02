using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public class BillDAO
    {
        static QUAN_LY_KHACH_SANEntities context = new QUAN_LY_KHACH_SANEntities();


        public static List<BillDTO> LoadDanhSach()
        {
            var query = (from p in context.PHIEU_THUE_PHONG
                         select new BillDTO
                         {
                             MaPhong = p.MaPhong,
                         });
            return query.ToList();
        }

        public static List<BillDTO> LayThongTinPhongThue(BillDTO infor)
        {
            var query = (from pt in context.PHIEU_THUE_PHONG
                         join p in context.PHONGs on pt.MaPhong equals p.MaPhong
                         join lp in context.LOAI_PHONG on p.MaLoaiPhong equals lp.MaLoaiPhong
                         join ctpt in context.CHI_TIET_PHIEU_THUE on pt.MaPhieuThue equals ctpt.MaPhieuThue
                         join kh in context.KHACH_HANG on ctpt.MaKhachHang equals kh.MaKhachHang

                         where pt.MaPhong == infor.MaPhong
                         select new BillDTO
                         {
                             NgayBatDauThue = pt.NgayBatDauThue,
                             MaPhong = pt.MaPhong,
                             MaPhieuThue = pt.MaPhieuThue,
                             TenKhachHang = kh.TenKhachHang,
                             DiaChi = kh.DiaChi,
                             DonGia = lp.DonGia,
                             //PhiDichVu = 

                         });
            return query.ToList();
        }

        public static object LayMaPhongDaThue()
        {
            var query = (from p in context.PHIEU_THUE_PHONG
                         select new BillDTO
                         {
                             MaPhong = p.MaPhong,
                         });
            return query.ToList();
        }

        public static int? LayMaHDCuoiCung()
        {
            int num = (from t in context.HOA_DON
                       select new BillDTO
                       {
                       }).Count();
            return num;
        }

        public static List<BillDTO> LayMaPhieuThue(int maphong)
        {
            var query = (from t in context.PHIEU_THUE_PHONG
                         where t.MaPhong == maphong
                         select new BillDTO
                         {
                             MaPhieuThue = t.MaPhieuThue
                         });
            return query.ToList();
        }

        public static bool XoaChiTietPhieuThue(BillDTO inforHD)
        {
            SqlParameter maphieuthue = new SqlParameter("@MaPT", inforHD.MaPhieuThue);

            try
            {
                context.Database.ExecuteSqlCommand("spXoaCTPhieuThue @MaPT", maphieuthue);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool XoaPhieuThue(BillDTO inforHD)
        {
            SqlParameter maphieuthue = new SqlParameter("@MaPT", inforHD.MaPhieuThue);

            try
            {
                context.Database.ExecuteSqlCommand("spXoaPhieuThue @MaPT", maphieuthue);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool LapChiTietHoaDon(BillDTO infor, BillDTO inforHD)
        {
            SqlParameter mahoadon = new SqlParameter("@MaHD", infor.MaHoaDon);
            SqlParameter songaythue = new SqlParameter("@SoNgayThue", inforHD.SoNgayDaThue);
            SqlParameter dongia = new SqlParameter("@DonGia", inforHD.DonGia);
            SqlParameter thanhtien = new SqlParameter("@ThanhTien", inforHD.ThanhTien);

            SqlParameter ngaythanhtoan = new SqlParameter("@NgayThanhToan", inforHD.NgayThanhToan);
            SqlParameter maphong = new SqlParameter("@MaPhong", inforHD.MaPhong);
            try
            {
                context.Database.ExecuteSqlCommand("spThemChiTietHD @MaHD , @SoNgayThue , @DonGia , @ThanhTien , @NgayThanhToan , @MaPhong", mahoadon, songaythue, dongia, thanhtien, ngaythanhtoan, maphong);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool LapHoaDon(BillDTO infor)
        {
            SqlParameter mahoadon = new SqlParameter("@MaHoaDon", infor.MaHoaDon);
            SqlParameter tenkh = new SqlParameter("@TenKhachHang", infor.TenKhachHang);
            SqlParameter trigia = new SqlParameter("@TriGia", infor.TongTien);
            try
            {
                context.Database.ExecuteSqlCommand("spThemHoaDon @MaHoaDon , @TenKhachHang , @TriGia", mahoadon, tenkh, trigia);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<BillDTO> TinhHeSo()
        {
            var query = (from t in context.THAM_SO
                         select new BillDTO
                         {
                             HeSo = t.HeSo,
                         });
            return query.ToList();
        }

        public static bool TinhSoNgayDaThue(BillDTO infor)
        {
            SqlParameter ngaythue = new SqlParameter("@NgayBDThue", infor.NgayBatDauThue);
            try
            {
                context.Database.ExecuteSqlCommand("spTruNgayThangNam @NgayBDThue", ngaythue);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static int DemSoLuongKhachNuocNgoai(BillDTO infor)
        {
            int num = (from pt in context.PHIEU_THUE_PHONG
                       join ctpt in context.CHI_TIET_PHIEU_THUE on pt.MaPhieuThue equals ctpt.MaPhieuThue
                       join kh in context.KHACH_HANG on ctpt.MaKhachHang equals kh.MaKhachHang
                       where pt.MaPhong == infor.MaPhong && kh.MaLoaiKhach == "LK002"
                       select new BillDTO
                       {

                       }).Count();
            return num;

        }

        public static List<BillDTO> LaySoNgayDaThue()
        {
            var query = (from t in context.THAM_SO
                         select new BillDTO
                         {
                             SoNgayDaThue = t.SoNgayThue,
                         });
            return query.ToList();
        }

        public static List<BillDTO> TinhPhuThu(int num)
        {
            var query = (from t in context.THAM_SO
                         select new BillDTO
                         {
                             PhuThu = t.PhuThu,
                         });
            return query.ToList();
        }

        public static int LaySoLuongKhach(int maphieuthue)
        {
            int num = (from pt in context.PHIEU_THUE_PHONG
                       join ct in context.CHI_TIET_PHIEU_THUE on pt.MaPhieuThue equals ct.MaPhieuThue
                       where ct.MaPhieuThue == maphieuthue
                       select new BillDTO
                       {

                       }).Count();
            return num;
        }

        public static List<BillDTO> LayKhachNuocNgoai()
        {
            var query = (from t in context.THAM_SO
                         select new BillDTO
                         {
                             KhachPTThu = t.PhuThuKhachThu,
                             SLKhachNG = t.SLKhachNuocNgoai,
                         });
            return query.ToList();
        }
    }
}
