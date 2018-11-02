using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class OderDichVuBUS
    {
        public static List<OderServiceDTO> LoadDanhSachMaPhong()
        {
            return OderServiceDAO.LoadDanhSachMaPhong();
        }

        public static List<OderServiceDTO> LoadDanhSachDichVu()
        {
            return OderServiceDAO.LoadDanhSachDichVu();
        }

        public static bool DangKiDichVu(OderServiceDTO infor)
        {
            if (infor.SoLuong > 0)
                return OderServiceDAO.DangKiDichVu(infor);
            else return false;
        }

        public static List<OderServiceDTO> LayMaDichVuDangKi(string tendichvu)
        {
            return OderServiceDAO.LayMaDichVuDangKi(tendichvu);
        }

        public static int LaySoLuongDichVuDK(int? maPhong)
        {
            return OderServiceDAO.LaySoLuongDichVuDK(maPhong);
        }

        public static List<OderServiceDTO> DanhSachDichVuDK(int? maPhong)
        {
            return OderServiceDAO.DanhSachDichVuDK(maPhong);
        }

        public static bool XoaDichVuPhongDK(BillDTO inforHD)
        {
            return OderServiceDAO.XoaDichVuPhongDK(inforHD);
        }
    }
}
