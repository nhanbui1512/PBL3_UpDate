//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace webpbl3.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class DatPhong
    {
        public int IDDatPhong { get; set; }
        public Nullable<int> IDTK { get; set; }
        public Nullable<int> IDPhong { get; set; }
        public Nullable<System.DateTime> BatDau { get; set; }
        public Nullable<System.DateTime> KetThuc { get; set; }
        public Nullable<bool> TrangThai { get; set; }
        public Nullable<int> IDHoaDon { get; set; }
        public Nullable<long> DonGia { get; set; }
        public Nullable<int> SoLuong { get; set; }
    
        public virtual HoaDon HoaDon { get; set; }
        public virtual Phong Phong { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
