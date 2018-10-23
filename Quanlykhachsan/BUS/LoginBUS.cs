using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class LoginBUS
    {
        public static List<LoginDTO> LayThongTinNguoiDung()
        {
            return LoginDAO.LayThongTinNguoiDung();
        }
        public static int DemSoLuongTK()
        {
            return LoginDAO.DemSoLuongTK();
        }
    }
}
