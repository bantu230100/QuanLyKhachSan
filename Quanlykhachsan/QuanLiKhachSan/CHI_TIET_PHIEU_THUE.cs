//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLiKhachSan
{
    using System;
    using System.Collections.Generic;
    
    public partial class CHI_TIET_PHIEU_THUE
    {
        public int MaChiTietPT { get; set; }
        public int MaKhachHang { get; set; }
        public int MaPhieuThue { get; set; }
    
        public virtual KHACH_HANG KHACH_HANG { get; set; }
        public virtual PHIEU_THUE_PHONG PHIEU_THUE_PHONG { get; set; }
    }
}