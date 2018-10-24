using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class RepostBUS
    {
        public static List<SalesRepostDTO> TinhTongDoanhThuTheoLoaiPhong()
        {
            return RepostDAO.TinhTongDoanhThuTheoLoaiPhong();
        }

        public static List<SalesRepostDTO> DoanhThuTheoLoaiPhongTheoThang(SalesRepostDTO infor)
        {
            DateTime ntm_min = Convert.ToDateTime("1990-01-01");
            DateTime ntm_max = Convert.ToDateTime("1990-01-31");
            string n1 = "-01"; string n2 = "-31"; string t = (infor.Thang).ToString(); string nam = (infor.Nam).ToString();
            if (infor.Thang == 2)
            {
                if ((infor.Nam % 4 != 0) || ((infor.Nam % 100 == 0) && (infor.Nam % 400 != 0)))
                {
                    n2 = "-28";
                }
                else
                {
                    n2 = "-29";
                }
            }
            else if (infor.Thang == 4 || infor.Thang == 6 || infor.Thang == 9 || infor.Thang == 11)
            {
                n2 = "-30";
            }
            string ntmold = nam + "-" + t + n1;
            string ntmnew = nam + "-" + t + n2;
            ntm_min = Convert.ToDateTime(ntmold);
            ntm_max = Convert.ToDateTime(ntmnew);
            return RepostDAO.DoanhThuTheoLoaiPhongTheoThang(ntm_min, ntm_max);
        }

        /*public static List<BCDoanhThuDTO> LayMaBCDoanhThuKeTiep()
        {
            return BaoCaoDAO.LayMaBCDoanhThuKeTiep();
        }

        public static List<BCDoanhThuDTO> LayMaBCCTDoanhThuKeTiep()
        {
            return BaoCaoDAO.LayMaBCCTDoanhThuKeTiep();
        }

        public static bool ThemBaoCaoDoanhThu(BCDoanhThuDTO infor)
        {
            return BaoCaoDAO.ThemBaoCaoDoanhThu(infor);
        }

        public static bool ThemCTBaoCaoDoanhThu(BCDoanhThuDTO infor)
        {
            return BaoCaoDAO.ThemCTBaoCaoDoanhThu(infor);
        }*/
    }
}
