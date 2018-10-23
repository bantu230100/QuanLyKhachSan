using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BUS;
using DTO;

namespace QuanLiKhachSan.UserControl
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTroGiup_Click(object sender, EventArgs e)
        {
            FormHelp pn = new FormHelp();
            pn.Show();
        }
        string TenTaiKhoan = "";
        string MatKhauTaiKhoan = "";
        int SLTK;
        List<LoginDTO> lst = new List<LoginDTO>();
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < SLTK; i++)
            {
                TenTaiKhoan = lst[i].TenDangNhap.TrimEnd();
                MatKhauTaiKhoan = lst[i].MatKhau.TrimEnd();
                DangNhapHeThong(TenTaiKhoan, MatKhauTaiKhoan);
            }
        }
        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            btnDangNhap.Enabled = true;
        }
        private void XoaTenVaMatKhau()
        {
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
        }

        private void DangNhapHeThong(string TenTaiKhoan, string MatKhauTaiKhoan)
        {
            if (txtTenDangNhap.Text == TenTaiKhoan && txtMatKhau.Text == MatKhauTaiKhoan)
            {
                frmMain f = new frmMain();
                this.Hide();
                f.ShowDialog();
                this.Show();
                XoaTenVaMatKhau();

                
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                XoaTenVaMatKhau();
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            lst = LoginBUS.LayThongTinNguoiDung();
            SLTK = LoginBUS.DemSoLuongTK();
        }
    }
}