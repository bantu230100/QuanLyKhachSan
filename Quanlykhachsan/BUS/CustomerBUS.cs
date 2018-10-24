using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class CustomerBUS
    {
        public static List<CustomerDTO> LayDSLoaiKhach()
        {
            return CustomerDAO.LayDSLoaiKhach();
        }

        public static bool ThemKhachHang(CustomerDTO kh)
        {
            return CustomerDAO.ThemKhachHang(kh);
        }

        public static List<CustomerDTO> DanhSachKhachHang()
        {
            return CustomerDAO.DanhSachKhachHang();
        }

        public static List<CustomerDTO> DSKHTheoTen(CustomerDTO thongtin)
        {
            return CustomerDAO.DSKHTheoTen(thongtin);
        }

        public static List<CustomerDTO> DSKHTheoTenDiaChi(CustomerDTO thongtin)
        {
            return CustomerDAO.DSKHTheoTenDiaChi(thongtin);
        }

        public static List<CustomerDTO> DSKHTheoTenLoaiKhach(CustomerDTO thongtin)
        {
            return CustomerDAO.DSKHTheoTenLoaiKhach(thongtin);
        }

        public static List<CustomerDTO> DSKHTheoTenDiaChiLoaiKhach(CustomerDTO thongtin)
        {
            return CustomerDAO.DSKHTheoTenDiaChiLoaiKhach(thongtin);
        }

        public static List<CustomerDTO> DSKHTheoLoaiKhach(CustomerDTO thongtin)
        {
            return CustomerDAO.DSKHTheoLoaiKhach(thongtin);
        }

        public static List<CustomerDTO> DSKHTheoLoaiKhachDiaChi(CustomerDTO thongtin)
        {
            return CustomerDAO.DSKHTheoLoaiKhachDiaChi(thongtin);
        }

        public static List<CustomerDTO> DSKHTheoDiaChi(CustomerDTO thongtin)
        {
            return CustomerDAO.DSKHTheoDiaChi(thongtin);
        }

        public static List<CustomerDTO> DSKHTheoPhong(RoomDTO thongtin)
        {
            return CustomerDAO.DSKHTheoPhong(thongtin);
        }

        public static List<CustomerDTO> DSKHTheoCMND(CustomerDTO thongtin)
        {
            return CustomerDAO.DSKHTheoCMND(thongtin);
        }

        public static List<CustomerDTO> DSKHTheoTenDiaChiLoaiKhachCMND(CustomerDTO thongtin)
        {
            return CustomerDAO.DSKHTheoTenDiaChiLoaiKhachCMND(thongtin);
        }

        public static List<CustomerDTO> DSKHTheoTenDiaChiCMND(CustomerDTO thongtin)
        {
            return CustomerDAO.DSKHTheoTenDiaChiCMND(thongtin);
        }

        public static List<CustomerDTO> DSKHTheoTenCMND(CustomerDTO thongtin)
        {
            return CustomerDAO.DSKHTheoTenCMND(thongtin);
        }

        public static List<CustomerDTO> DSKHTheoTenLoaiKhachCMND(CustomerDTO thongtin)
        {
            return CustomerDAO.DSKHTheoTenLoaiKhachCMND(thongtin);
        }

        public static List<CustomerDTO> DSKHLoaiKhachCMND(CustomerDTO thongtin)
        {
            return CustomerDAO.DSKHTheoLoaiKhachCMND(thongtin);
        }

        public static List<CustomerDTO> DSKHDiaChiLoaiKhachCMND(CustomerDTO thongtin)
        {
            return CustomerDAO.DSKHDiaChiLoaiKhachCMND(thongtin);
        }

        public static List<CustomerDTO> DSKHDiaChiCMND(CustomerDTO thongtin)
        {
            return CustomerDAO.DSKHDiaChiCMND(thongtin);
        }

        public static List<CustomerDTO> LayMaKhachHangCanXoa(int? maphieuthue)
        {
            return CustomerDAO.LayMaKhachHangCanXoa(maphieuthue);
        }

        public static bool XoaKhachHang(CustomerDTO id)
        {
            return CustomerDAO.XoaKhachHang(id);
        }
    }
}
