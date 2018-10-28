using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class RoomBUS
    {
        //11111111111111
        public static List<RoomDTO> LayMaPhongLoaiPhong()
        {
            return RoomDAO.LayMaPhongLoaiPhong();
        }

        //2222222222222222222222222
        public static List<RoomDTO> LayDanhSachLoaiPhong()
        {
            return RoomDAO.LayDanhSachLoaiPhong();
        }

        //33333333333333
        public static int LaySLPhongTrongTheoLoai(string lp)
        {
            return RoomDAO.LaySLPhongTrongTheoLoai(lp);
        }

        public static List<ParameDTO> SoLuongKhachToiDa()
        {
            return RoomDAO.SoLuongKhachToiDa();
        }

        public static bool CapNhatTinhTrangPhong(PhieuThuePhongDTO p)
        {
            return RoomDAO.CapNhatTinhTrangPhong(p);
        }

        public static List<RoomDTO> DanhSachPhongTK()
        {
            return RoomDAO.DanhSachPhongTK();
        }

        public static List<RoomDTO> LoaiPhong()
        {
            return RoomDAO.LoaiPhong();
        }

        public static List<PhieuThuePhongDTO> DanhSachPhongDangDuocThue()
        {
            return RoomDAO.DanhSachPhongDangDuocThue();
        }

        public static List<RoomDTO> DanhSachPhong()
        {
            return RoomDAO.DanhSachPhong();
        }

        public static List<RoomDTO> LoadDonGia(string text)
        {
            return RoomDAO.LoadDonGia(text);
        }

        public static bool ThemPhong(RoomDTO infor)
        {
            return RoomDAO.ThemPhong(infor);
        }

        public static bool SuaThongTinPhong(RoomDTO infor)
        {
            return RoomDAO.SuaThongTinPhong(infor);
        }

        public static bool XoaPhong(RoomDTO infor)
        {
            return RoomDAO.XoaPhong(infor);
        }

        public static bool ThietLapTrangThaiPhongBanDau(BillDTO inforHD)
        {
            return RoomDAO.ThietLapTrangThaiPhongBanDau(inforHD);
        }

        public static List<RoomDTO> DanhSachPhongTheoLoai(RoomDTO thongtin)
        {
            return RoomDAO.DanhSachPhongTheoLoai(thongtin);
        }

        public static List<RoomDTO> DanhSachPhongYeuCau(RoomDTO thongtin)
        {
            return RoomDAO.DanhSachPhongYeuCau(thongtin);
        }

        public static List<RoomDTO> DanhSachPhongTheoLoaiTheoYeuCau(RoomDTO thongtin)
        {
            return RoomDAO.DanhSachPhongTheoLoaiTheoYeuCau(thongtin);
        }

        public static List<RoomDTO> DanhSachPhongTheoDGTu(decimal dgtu)
        {
            return RoomDAO.DanhSachPhongTheoDGTu(dgtu);
        }

        public static List<RoomDTO> DanhSachPhongTheoKhoangDG(decimal dgtu, decimal dgden)
        {
            return RoomDAO.DanhSachPhongTheoKhoangDG(dgtu, dgden);
        }

        public static List<RoomDTO> DanhSachPhongTheoDGDen(decimal dgden)
        {
            return RoomDAO.DanhSachPhongTheoDGDen(dgden);
        }

        public static List<PhieuThuePhongDTO> NgayTraPhong()
        {
            return RoomDAO.NgayTraPhong();
        }

        public static object DanhSachPhongTraGanNhat()
        {
            return RoomDAO.DanhSachPhongTraGanNhat();
        }

        public static bool XoaPhongTrongCTHoaDon(RoomDTO infor)
        {
            return RoomDAO.XoaPhongTrongCTHoaDon(infor);
        }
    }
}
