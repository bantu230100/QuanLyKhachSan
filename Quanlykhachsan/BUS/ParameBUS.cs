using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class ParameBUS
    {
        public static List<ParameDTO> LoadSoLuongKhach()
        {
            return ParameDAO.LoadSoLuongKhach();
        }

        public static List<ParameDTO> LoadHeSo()
        {
            return ParameDAO.LoadHeSo();
        }

        public static List<ParameDTO> LoadPhuThu()
        {
            return ParameDAO.LoadPhuThu();
        }

        public static bool CapNhatTSSoKhachToiDa(ParameDTO infor)
        {
            return ParameDAO.CapNhatTSSoKhachToiDa(infor);
        }

        public static bool CapNhatTSHeSo(ParameDTO infor)
        {
            return ParameDAO.CapNhatTSHeSo(infor);
        }

        public static bool CapNhatTSPhuThu(ParameDTO infor)
        {
            return ParameDAO.CapNhatTSPhuThu(infor);
        }

        public static List<ParameDTO> LayThongTinTS()
        {
            return ParameDAO.LayThongTinTS();
        }

        public static List<ParameDTO> LoadDonGia(string text)
        {
            return ParameDAO.LoadDonGia(text);
        }

        public static bool CapNhatTSDonGia(ParameDTO ts, string t)
        {
            if (ts.DonGia <= 0)
                return false;
            return ParameDAO.CapNhatTSDonGia(ts, t);
        }
    }
}
