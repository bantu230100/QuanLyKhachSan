using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class BillBUS
    {
        public static List<BillDTO> LoadMaPhong()
        {
            return BillDAO.LoadDanhSach();
        }

        public static List<BillDTO> LayThongTinPhongThue(BillDTO infor)
        {
            return BillDAO.LayThongTinPhongThue(infor);
        }

        public static bool TinhSoNgayDaThue(BillDTO infor)
        {
            return BillDAO.TinhSoNgayDaThue(infor);
        }

        public static List<BillDTO> LaySoNgayDaThue()
        {
            return BillDAO.LaySoNgayDaThue();
        }

        public static object LayMaPhongDaThue()
        {
            return BillDAO.LayMaPhongDaThue();
        }

        public static int LaySoLuongKhach(int maphieuthue)
        {
            return BillDAO.LaySoLuongKhach(maphieuthue);
        }

        public static List<BillDTO> LayKhachNuocNgoai()
        {
            return BillDAO.LayKhachNuocNgoai();
        }

        public static List<BillDTO> TinhPhuThu(int num)
        {
            return BillDAO.TinhPhuThu(num);
        }

        public static int DemSoLuongKhachNuocNgoai(BillDTO infor)
        {
            return BillDAO.DemSoLuongKhachNuocNgoai(infor);
        }

        public static List<BillDTO> TinhHeSo()
        {
            return BillDAO.TinhHeSo();
        }

        public static decimal ThanhTien(int snt, decimal dg, decimal pt, decimal hs, decimal pdv)
        {
            decimal thanhtien = 0;
            if (hs != 0)
                thanhtien = dg * snt * (hs + pt) + pdv;
            else
                thanhtien = dg * snt * (1 + pt) + pdv;
            return thanhtien;
        }
      

        public static int? LayMaHDCuoiCung()
        {
            return BillDAO.LayMaHDCuoiCung();
        }

        public static bool LapHoaDon(BillDTO infor)
        {
            return BillDAO.LapHoaDon(infor);
        }

        public static List<BillDTO> LayMaPhieuThue(int maphong)
        {
            return BillDAO.LayMaPhieuThue(maphong);
        }

        public static bool LapChiTietHoaDon(BillDTO infor, BillDTO inforHD)
        {
            return BillDAO.LapChiTietHoaDon(infor, inforHD);
        }

        public static bool XoaChiTietPhieuThue(BillDTO inforHD)
        {
            return BillDAO.XoaChiTietPhieuThue(inforHD);
        }

        public static bool XoaPhieuThue(BillDTO inforHD)
        {
            return BillDAO.XoaPhieuThue(inforHD);
        }
    }
}
