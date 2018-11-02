using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public class ParameDAO
    {
        static QUAN_LY_KHACH_SANEntities context = new QUAN_LY_KHACH_SANEntities();

        public static List<ParameDTO> LoadSoLuongKhach()
        {
            var query = (from ts in context.THAM_SO
                         select new ParameDTO
                         {
                             SLKhachToiDa = ts.SoKhachToiDa,
                         });
            return query.ToList();
        }

        public static List<ParameDTO> LoadPhuThu()
        {
            var query = (from ts in context.THAM_SO
                         select new ParameDTO
                         {
                             PhuThu = ts.PhuThu,
                         });
            return query.ToList();
        }

        public static bool CapNhatTSPhuThu(ParameDTO infor)
        {
            SqlParameter phuthu = new SqlParameter("@PhuThu", infor.PhuThu);
            try
            {
                context.Database.ExecuteSqlCommand("spCapNhatTSPhuThu @PhuThu", phuthu);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<ParameDTO> LoadDonGia(string text)
        {
            var query = (from t in context.LOAI_PHONG

                         where t.TenLoaiPhong == text
                         select new ParameDTO
                         {
                             DonGia = t.DonGia,
                         });
            return query.ToList();
        }

        public static bool CapNhatTSDonGia(ParameDTO ts, string t)
        {
            SqlParameter dongia = new SqlParameter("@DonGia", ts.DonGia);
            SqlParameter tenloaiphong = new SqlParameter("@TenLoaiPhong", t);
            try
            {
                context.Database.ExecuteSqlCommand("spCapNhatTSDonGia  @TenLoaiPhong ,@DonGia ", dongia, tenloaiphong);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<ParameDTO> LayThongTinTS()
        {
            var query = (from t in context.THAM_SO
                         select new ParameDTO
                         {
                             SLKhachToiDa = t.SoKhachToiDa,
                             HeSo = t.HeSo,
                             PhuThu = t.PhuThu
                         });
            return query.ToList();
        }

        public static bool CapNhatTSHeSo(ParameDTO infor)
        {
            SqlParameter heso = new SqlParameter("@HeSo", infor.HeSo);
            try
            {
                context.Database.ExecuteSqlCommand("spCapNhatTSHeSo @HeSo", heso);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool CapNhatTSSoKhachToiDa(ParameDTO infor)
        {
            SqlParameter toida = new SqlParameter("@SoKhachToiDa", infor.SLKhachToiDa);
            try
            {
                context.Database.ExecuteSqlCommand("spCapNhatTSSoKhachToiDa @SoKhachToiDa", toida);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<ParameDTO> LoadHeSo()
        {
            var query = (from ts in context.THAM_SO
                         select new ParameDTO
                         {
                             HeSo = ts.HeSo,
                         });
            return query.ToList();
        }
    }
}
