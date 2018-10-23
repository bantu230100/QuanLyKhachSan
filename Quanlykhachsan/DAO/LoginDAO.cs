using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class LoginDAO
    {
        static QUAN_LY_KHACH_SANEntities context = new QUAN_LY_KHACH_SANEntities();
        public static List<LoginDTO> LayThongTinNguoiDung()
        {
            var query = (from t in context.NGUOI_DUNG
                         select new LoginDTO
                         {
                             TenDangNhap = t.TenTaiKhoan,
                             MatKhau = t.MatKhau,

                         });
            return query.ToList();
        }
        public static int DemSoLuongTK()
        {
            int query = (from t in context.NGUOI_DUNG
                         select new LoginDTO
                         {

                         }).Count();
            return query;
        }
    }
}
