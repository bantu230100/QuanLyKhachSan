using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public class ServiceDAO
    {
        static QUAN_LY_KHACH_SANEntities context = new QUAN_LY_KHACH_SANEntities();
        public static List<ServiceDTO> LoadDanhSach()
        {
            var query = (from t in context.DICH_VU

                         select new ServiceDTO
                         {
                             MaDichVu = t.MaDichVu,
                             TenDichVu = t.TenDichVu,
                             DonViTinh = t.DonViTinh,
                             DonGia = t.DonGia
                         });
            return query.ToList();
        }

        public static bool ThemDichVu(ServiceDTO infor)
        {
            SqlParameter tendichvu = new SqlParameter("@TenDichVu", infor.TenDichVu);
            SqlParameter donvitinh = new SqlParameter("@DonViTinh", infor.DonViTinh);
            SqlParameter dongia = new SqlParameter("@DonGia", infor.DonGia);

            try
            {
                context.Database.ExecuteSqlCommand("spThemDichVu @TenDichVu, @DonViTinh, @DonGia",
                                    tendichvu, donvitinh, dongia);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<ServiceDTO> LayDonGia(int maDichVu)
        {
            var query = (from t in context.DICH_VU
                         where t.MaDichVu == maDichVu
                         select new ServiceDTO
                         {
                             DonGia = t.DonGia
                         });
            return query.ToList();
        }

        public static bool SuaThongTinDichVu(ServiceDTO infor)
        {
            SqlParameter madichvu = new SqlParameter("@MaDichVu", infor.MaDichVu);
            SqlParameter tendichvu = new SqlParameter("@TenDichVu", infor.TenDichVu);
            SqlParameter donvitinh = new SqlParameter("@DonViTinh", infor.DonViTinh);
            SqlParameter dongia = new SqlParameter("@DonGia", infor.DonGia);

            try
            {
                context.Database.ExecuteSqlCommand("spSuaThongTinDichVu @MaDichVu, @TenDichVu, @DonViTinh, @DonGia",
                                    madichvu, tendichvu, donvitinh, dongia);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool XoaDichVu(ServiceDTO infor)
        {
            SqlParameter madichvu = new SqlParameter("@MaDichVu", infor.MaDichVu);
            try
            {
                context.Database.ExecuteSqlCommand("spXoaDichVu @MaDichVu", madichvu);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
