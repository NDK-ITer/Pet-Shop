//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pet_Shop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CT_HoaDon
    {
        public string SoHD { get; set; }
        public string MaDT { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<decimal> ThanhTien { get; set; }
    
        public virtual HoaDon HoaDon { get; set; }
        public virtual DoiTuongKD DoiTuongKD { get; set; }
    }
}
