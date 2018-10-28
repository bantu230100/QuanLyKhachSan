using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class RentalBUS
    {
        public static List<CustomerDTO> LayMaKHKeTiep()
        {
            return RentalDAO.LayMaKHKeTiep();
        }

        public static List<PhieuThuePhongDTO> LayMaPTKeTiep()
        {
            return RentalDAO.LayMaPTKeTiep();
        }

        public static List<PhieuThuePhongDTO> LayMaCTPTKeTiep()
        {
            return RentalDAO.LayMaCTPTKeTiep();
        }

        public static bool ThemPhieuThuePhong(ChiTietPhieuThueDTO ct, PhieuThuePhongDTO p)
        {
            int i = DateTime.Compare(p.NgayThue, p.NgayTraPhong.Value);
            if (i <= 0)
                return RentalDAO.ThemPhieuThuePhong(ct, p);
            return false;
        }

        public static bool ThemCTPhieuThuePhong(ChiTietPhieuThueDTO ct, CustomerDTO kh)
        {
            return RentalDAO.ThemCTPhieuThuePhong(ct, kh);
        }

        public static List<PhieuThuePhongDTO> LayPhongTuongUng(int makh)
        {
            return RentalDAO.LayPhongTuongUng(makh);
        }
    }
}
