using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public class CustomerDAO
    {
        static QUAN_LY_KHACH_SANEntities context = new QUAN_LY_KHACH_SANEntities();


        public static List<CustomerDTO> LayDSLoaiKhach()
        {
            var query = (from t in context.LOAI_KHACH_HANG
                         select new CustomerDTO
                         {
                             MaLoaiKhach = t.MaLoaiKhach,
                             LoaiKhach = t.TenLoaiKhach,
                         });
            return query.ToList();
        }

        public static bool ThemKhachHang(CustomerDTO kh)
        {
            SqlParameter makh = new SqlParameter("@MaKH", kh.MaKH);
            SqlParameter tenkh = new SqlParameter("@TenKH", kh.TenKhachHang);
            SqlParameter cmnd = new SqlParameter("@CMND", kh.CMND);
            SqlParameter diachi = new SqlParameter("@DiaChi", kh.DiaChi);
            SqlParameter malk = new SqlParameter("@MaLK", kh.MaLoaiKhach);
            try
            {
                context.Database.ExecuteSqlCommand("spThemKhachHang @MaKH, @TenKH, @CMND, @DiaChi, @MaLK", makh, tenkh, cmnd, diachi, malk);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<CustomerDTO> DanhSachKhachHang()
        {
            var query = (from c in context.KHACH_HANG
                         join t in context.LOAI_KHACH_HANG on c.MaLoaiKhach equals t.MaLoaiKhach
                         select new CustomerDTO
                         {
                             MaKH = c.MaKhachHang,
                             TenKhachHang = c.TenKhachHang,
                             CMND = c.CMND,
                             LoaiKhach = t.TenLoaiKhach,
                             DiaChi = c.DiaChi,
                         }).OrderBy(x => x.LoaiKhach);
            return query.ToList();
        }

        public static List<CustomerDTO> DSKHTheoCMND(CustomerDTO thongtin)
        {
            var query = (from kh in context.KHACH_HANG
                         join lk in context.LOAI_KHACH_HANG on kh.MaLoaiKhach equals lk.MaLoaiKhach
                         where kh.CMND.Contains(thongtin.CMND)
                         select new CustomerDTO
                         {
                             MaKH = kh.MaKhachHang,
                             TenKhachHang = kh.TenKhachHang,
                             LoaiKhach = lk.TenLoaiKhach,
                             CMND = kh.CMND,
                             DiaChi = kh.DiaChi,
                         }).OrderBy(x => x.LoaiKhach);
            return query.ToList();
        }

        public static List<CustomerDTO> DSKHTheoTenLoaiKhachCMND(CustomerDTO thongtin)
        {
            var query = (from kh in context.KHACH_HANG
                         join lk in context.LOAI_KHACH_HANG on kh.MaLoaiKhach equals lk.MaLoaiKhach
                         where kh.CMND.Contains(thongtin.CMND) && kh.TenKhachHang.Contains(thongtin.TenKhachHang) && lk.TenLoaiKhach.Contains(thongtin.LoaiKhach)
                         select new CustomerDTO
                         {
                             MaKH = kh.MaKhachHang,
                             TenKhachHang = kh.TenKhachHang,
                             LoaiKhach = lk.TenLoaiKhach,
                             CMND = kh.CMND,
                             DiaChi = kh.DiaChi,
                         }).OrderBy(x => x.LoaiKhach);
            return query.ToList();
        }

        public static bool XoaKhachHang(CustomerDTO id)
        {
            SqlParameter makh = new SqlParameter("@MaKH", id.MaKH);
            try
            {
                context.Database.ExecuteSqlCommand("spXoaKhachHang @MaKH", makh);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<CustomerDTO> LayMaKhachHangCanXoa(int? maphieuthue)
        {
            var query = (from kh in context.KHACH_HANG
                         join ct in context.CHI_TIET_PHIEU_THUE on kh.MaKhachHang equals ct.MaKhachHang
                         where ct.MaPhieuThue == maphieuthue
                         select new CustomerDTO
                         {
                             MaKH = kh.MaKhachHang,
                         });
            return query.ToList();
        }

        public static List<CustomerDTO> DSKHDiaChiCMND(CustomerDTO thongtin)
        {
            var query = (from kh in context.KHACH_HANG
                         join lk in context.LOAI_KHACH_HANG on kh.MaLoaiKhach equals lk.MaLoaiKhach
                         where kh.CMND.Contains(thongtin.CMND) && kh.DiaChi.Contains(thongtin.DiaChi)
                         select new CustomerDTO
                         {
                             MaKH = kh.MaKhachHang,
                             TenKhachHang = kh.TenKhachHang,
                             LoaiKhach = lk.TenLoaiKhach,
                             CMND = kh.CMND,
                             DiaChi = kh.DiaChi,
                         }).OrderBy(x => x.LoaiKhach);
            return query.ToList();
        }

        public static List<CustomerDTO> DSKHDiaChiLoaiKhachCMND(CustomerDTO thongtin)
        {
            var query = (from kh in context.KHACH_HANG
                         join lk in context.LOAI_KHACH_HANG on kh.MaLoaiKhach equals lk.MaLoaiKhach
                         where kh.CMND.Contains(thongtin.CMND) && kh.DiaChi.Contains(thongtin.DiaChi) && lk.TenLoaiKhach.Contains(thongtin.LoaiKhach)
                         select new CustomerDTO
                         {
                             MaKH = kh.MaKhachHang,
                             TenKhachHang = kh.TenKhachHang,
                             LoaiKhach = lk.TenLoaiKhach,
                             CMND = kh.CMND,
                             DiaChi = kh.DiaChi,
                         }).OrderBy(x => x.LoaiKhach);
            return query.ToList();
        }

        public static List<CustomerDTO> DSKHTheoLoaiKhachCMND(CustomerDTO thongtin)
        {
            var query = (from kh in context.KHACH_HANG
                         join lk in context.LOAI_KHACH_HANG on kh.MaLoaiKhach equals lk.MaLoaiKhach
                         where kh.CMND.Contains(thongtin.CMND) && lk.TenLoaiKhach.Contains(thongtin.LoaiKhach)
                         select new CustomerDTO
                         {
                             MaKH = kh.MaKhachHang,
                             TenKhachHang = kh.TenKhachHang,
                             LoaiKhach = lk.TenLoaiKhach,
                             CMND = kh.CMND,
                             DiaChi = kh.DiaChi,
                         }).OrderBy(x => x.LoaiKhach);
            return query.ToList();
        }

        public static List<CustomerDTO> DSKHTheoTenCMND(CustomerDTO thongtin)
        {
            var query = (from kh in context.KHACH_HANG
                         join lk in context.LOAI_KHACH_HANG on kh.MaLoaiKhach equals lk.MaLoaiKhach
                         where kh.CMND.Contains(thongtin.CMND) && kh.TenKhachHang.Contains(thongtin.TenKhachHang)
                         select new CustomerDTO
                         {
                             MaKH = kh.MaKhachHang,
                             TenKhachHang = kh.TenKhachHang,
                             LoaiKhach = lk.TenLoaiKhach,
                             CMND = kh.CMND,
                             DiaChi = kh.DiaChi,
                         }).OrderBy(x => x.LoaiKhach);
            return query.ToList();
        }

        public static List<CustomerDTO> DSKHTheoTenDiaChiCMND(CustomerDTO thongtin)
        {
            var query = (from kh in context.KHACH_HANG
                         join lk in context.LOAI_KHACH_HANG on kh.MaLoaiKhach equals lk.MaLoaiKhach
                         where kh.CMND.Contains(thongtin.CMND) && kh.TenKhachHang.Contains(thongtin.TenKhachHang) && kh.DiaChi.Contains(thongtin.DiaChi)
                         select new CustomerDTO
                         {
                             MaKH = kh.MaKhachHang,
                             TenKhachHang = kh.TenKhachHang,
                             LoaiKhach = lk.TenLoaiKhach,
                             CMND = kh.CMND,
                             DiaChi = kh.DiaChi,
                         }).OrderBy(x => x.LoaiKhach);
            return query.ToList();
        }

        public static List<CustomerDTO> DSKHTheoTenDiaChiLoaiKhachCMND(CustomerDTO thongtin)
        {
            var query = (from kh in context.KHACH_HANG
                         join lk in context.LOAI_KHACH_HANG on kh.MaLoaiKhach equals lk.MaLoaiKhach
                         where kh.CMND.Contains(thongtin.CMND) && kh.TenKhachHang.Contains(thongtin.TenKhachHang) && lk.TenLoaiKhach == thongtin.LoaiKhach && kh.DiaChi.Contains(thongtin.DiaChi)
                         select new CustomerDTO
                         {
                             MaKH = kh.MaKhachHang,
                             TenKhachHang = kh.TenKhachHang,
                             LoaiKhach = lk.TenLoaiKhach,
                             CMND = kh.CMND,
                             DiaChi = kh.DiaChi,
                         }).OrderBy(x => x.LoaiKhach);
            return query.ToList();
        }

        public static List<CustomerDTO> DSKHTheoTen(CustomerDTO thongtin)
        {
            var query = (from kh in context.KHACH_HANG
                         join lk in context.LOAI_KHACH_HANG on kh.MaLoaiKhach equals lk.MaLoaiKhach
                         where kh.TenKhachHang.Contains(thongtin.TenKhachHang)
                         select new CustomerDTO
                         {
                             MaKH = kh.MaKhachHang,
                             TenKhachHang = kh.TenKhachHang,
                             LoaiKhach = lk.TenLoaiKhach,
                             CMND = kh.CMND,
                             DiaChi = kh.DiaChi,
                         }).OrderBy(x => x.LoaiKhach);
            return query.ToList();
        }

        public static List<CustomerDTO> DSKHTheoTenDiaChi(CustomerDTO thongtin)
        {
            var query = (from kh in context.KHACH_HANG
                         join lk in context.LOAI_KHACH_HANG on kh.MaLoaiKhach equals lk.MaLoaiKhach
                         where kh.TenKhachHang.Contains(thongtin.TenKhachHang) && kh.DiaChi.Contains(thongtin.DiaChi)
                         select new CustomerDTO
                         {
                             MaKH = kh.MaKhachHang,
                             TenKhachHang = kh.TenKhachHang,
                             LoaiKhach = lk.TenLoaiKhach,
                             CMND = kh.CMND,
                             DiaChi = kh.DiaChi,
                         }).OrderBy(x => x.LoaiKhach);
            return query.ToList();
        }

        public static List<CustomerDTO> DSKHTheoTenLoaiKhach(CustomerDTO thongtin)
        {
            var query = (from kh in context.KHACH_HANG
                         join lk in context.LOAI_KHACH_HANG on kh.MaLoaiKhach equals lk.MaLoaiKhach
                         where kh.TenKhachHang.Contains(thongtin.TenKhachHang) && lk.TenLoaiKhach == thongtin.LoaiKhach
                         select new CustomerDTO
                         {
                             MaKH = kh.MaKhachHang,
                             TenKhachHang = kh.TenKhachHang,
                             LoaiKhach = lk.TenLoaiKhach,
                             CMND = kh.CMND,
                             DiaChi = kh.DiaChi,
                         }).OrderBy(x => x.LoaiKhach);
            return query.ToList();
        }

        public static List<CustomerDTO> DSKHTheoTenDiaChiLoaiKhach(CustomerDTO thongtin)
        {
            var query = (from kh in context.KHACH_HANG
                         join lk in context.LOAI_KHACH_HANG on kh.MaLoaiKhach equals lk.MaLoaiKhach
                         where kh.TenKhachHang.Contains(thongtin.TenKhachHang) && lk.TenLoaiKhach == thongtin.LoaiKhach && kh.DiaChi.Contains(thongtin.DiaChi)
                         select new CustomerDTO
                         {
                             MaKH = kh.MaKhachHang,
                             TenKhachHang = kh.TenKhachHang,
                             LoaiKhach = lk.TenLoaiKhach,
                             CMND = kh.CMND,
                             DiaChi = kh.DiaChi,
                         }).OrderBy(x => x.LoaiKhach);
            return query.ToList();
        }

        public static List<CustomerDTO> DSKHTheoLoaiKhach(CustomerDTO thongtin)
        {
            var query = (from kh in context.KHACH_HANG
                         join lk in context.LOAI_KHACH_HANG on kh.MaLoaiKhach equals lk.MaLoaiKhach
                         where lk.TenLoaiKhach == thongtin.LoaiKhach
                         select new CustomerDTO
                         {
                             MaKH = kh.MaKhachHang,
                             TenKhachHang = kh.TenKhachHang,
                             LoaiKhach = lk.TenLoaiKhach,
                             CMND = kh.CMND,
                             DiaChi = kh.DiaChi,
                         }).OrderBy(x => x.LoaiKhach);
            return query.ToList();
        }

        public static List<CustomerDTO> DSKHTheoLoaiKhachDiaChi(CustomerDTO thongtin)
        {
            var query = (from kh in context.KHACH_HANG
                         join lk in context.LOAI_KHACH_HANG on kh.MaLoaiKhach equals lk.MaLoaiKhach
                         where lk.TenLoaiKhach == thongtin.LoaiKhach && kh.DiaChi.Contains(thongtin.DiaChi)
                         select new CustomerDTO
                         {
                             MaKH = kh.MaKhachHang,
                             TenKhachHang = kh.TenKhachHang,
                             LoaiKhach = lk.TenLoaiKhach,
                             CMND = kh.CMND,
                             DiaChi = kh.DiaChi,
                         }).OrderBy(x => x.LoaiKhach);
            return query.ToList();
        }

        public static List<CustomerDTO> DSKHTheoDiaChi(CustomerDTO thongtin)
        {
            var query = (from kh in context.KHACH_HANG
                         join lk in context.LOAI_KHACH_HANG on kh.MaLoaiKhach equals lk.MaLoaiKhach
                         where kh.DiaChi.Contains(thongtin.DiaChi)
                         select new CustomerDTO
                         {
                             MaKH = kh.MaKhachHang,
                             TenKhachHang = kh.TenKhachHang,
                             LoaiKhach = lk.TenLoaiKhach,
                             CMND = kh.CMND,
                             DiaChi = kh.DiaChi,
                         }).OrderBy(x => x.LoaiKhach);
            return query.ToList();
        }

        public static List<CustomerDTO> DSKHTheoPhong(RoomDTO thongtin)
        {
            var query = (from lk in context.LOAI_KHACH_HANG
                         join kh in context.KHACH_HANG on lk.MaLoaiKhach equals kh.MaLoaiKhach
                         join ct in context.CHI_TIET_PHIEU_THUE on kh.MaKhachHang equals ct.MaKhachHang
                         join pt in context.PHIEU_THUE_PHONG on ct.MaPhieuThue equals pt.MaPhieuThue
                         where pt.MaPhong == thongtin.MaPhong
                         select new CustomerDTO
                         {
                             MaKH = kh.MaKhachHang,
                             TenKhachHang = kh.TenKhachHang,
                             LoaiKhach = lk.TenLoaiKhach,
                             CMND = kh.CMND,
                             DiaChi = kh.DiaChi,
                         });
            return query.ToList();
        }
    }
}
