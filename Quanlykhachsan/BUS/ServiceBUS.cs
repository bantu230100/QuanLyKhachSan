using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class ServiceBUS
    {
        public static List<ServiceDTO> LoadDanhSach()
        {
            return ServiceDAO.LoadDanhSach();
        }

        public static bool XoaDichVu(ServiceDTO infor)
        {
            return ServiceDAO.XoaDichVu(infor);
        }

        public static bool SuaThongTinDichVu(ServiceDTO infor)
        {
            return ServiceDAO.SuaThongTinDichVu(infor);
        }

        public static bool ThemDichVu(ServiceDTO infor)
        {
            return ServiceDAO.ThemDichVu(infor);
        }

        public static List<ServiceDTO> LayDonGia(int maDichVu)
        {
            return ServiceDAO.LayDonGia(maDichVu);
        }
    }
}
