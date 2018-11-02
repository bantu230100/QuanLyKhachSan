using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public class OderServiceDAO
    {
        static QUAN_LY_KHACH_SANEntities context = new QUAN_LY_KHACH_SANEntities();

        public static List<OderServiceDTO> LoadDanhSachMaPhong()
        {
            var query = (from t in context.PHONGs
                         where t.TinhTrang == "Đầy"
                         select new OderServiceDTO
                         {
                             MaPhong = t.MaPhong,
                         });
            return query.ToList();

        }

        public static bool DangKiDichVu(OderServiceDTO infor)
        {
            SqlParameter MaDichVu = new SqlParameter("@MaDichVu", infor.MaDichVu);
            SqlParameter maphong = new SqlParameter("@MaPhong", infor.MaPhong);
            SqlParameter soluong = new SqlParameter("@SoLuong", infor.SoLuong);
            try
            {
                context.Database.ExecuteSqlCommand("spDangKiDichVu @MaDichVu, @MaPhong , @SoLuong", MaDichVu, maphong, soluong);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool XoaDichVuPhongDK(BillDTO inforHD)
        {
            SqlParameter maphong = new SqlParameter("@MaPhong", inforHD.MaPhong);
            try
            {
                context.Database.ExecuteSqlCommand("spXoaDichVuPhongDK  @MaPhong ", maphong);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<OderServiceDTO> DanhSachDichVuDK(int? maPhong)
        {
            var query = (from t in context.DANG_KI_DICH_VU
                         where t.MaPhong == maPhong
                         select new OderServiceDTO
                         {
                             MaDichVu = t.MaDichVu,
                             SoLuong = t.SoLuong,
                         });
            return query.ToList();
        }

        public static int LaySoLuongDichVuDK(int? maPhong)
        {
            int num = (from t in context.DANG_KI_DICH_VU
                       where t.MaPhong == maPhong
                       select new OderServiceDTO
                       { }).Count();
            return num;
        }

        public static List<OderServiceDTO> LayMaDichVuDangKi(string tendichvu)
        {
            var query = (
                         from y in context.DICH_VU
                         where y.TenDichVu == tendichvu
                         select new OderServiceDTO
                         {
                             MaDichVu = y.MaDichVu,
                         });
            return query.ToList();
        }

        public static List<OderServiceDTO> LoadDanhSachDichVu()
        {
            var query = (from t in context.DICH_VU

                         select new OderServiceDTO
                         {
                             TenDichVu = t.TenDichVu,

                         });
            return query.ToList();
        }
    }
}
