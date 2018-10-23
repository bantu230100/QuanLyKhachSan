using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLiKhachSan
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();         
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Skins();
            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(new UserControl.FormMain());
        }

        public void Skins()
        {
            DevExpress.LookAndFeel.DefaultLookAndFeel themes = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            themes.LookAndFeel.SkinName = "Summer 2008";
            
        }
        

        private void tabHienThi_Click(object sender, EventArgs e)
        {

        }

        private void btnQuanLiPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(new UserControl.FormRoomsInfo());
        }

        private void btnQuanLiDichVu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(new UserControl.FormServiceManagetment());
        }

        private void btnTimPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(new UserControl.FormRoom());
        }

        private void btnTimKhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(new UserControl.FormSearchHotel());
        }

        private void btnDoanhThu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(new UserControl.FormRenvenue());
        }

        private void btnTraPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(new UserControl.FormCheckOut());
        }

        private void btnDatPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(new UserControl.FormEmptyRooms());
        }

        private void btnOder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserControl.formOderService oder = new UserControl.formOderService();
            oder.ShowDialog();
        }

        private void btnThayDoiQuyDinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserControl.FormRegulations quydinh = new UserControl.FormRegulations();
            quydinh.ShowDialog();
        }

        private void btnTroGiup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserControl.FormHelp help = new UserControl.FormHelp();
            help.ShowDialog();
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserControl.FormHelp pn = new UserControl.FormHelp();
            pn.ShowDialog();
        }

        private void btnLogOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(new UserControl.FormMain());
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(new UserControl.FormMain());
        }
    }
}
