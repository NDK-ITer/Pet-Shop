﻿//------------------------------------------------------------------------------
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
    using System.ComponentModel;

    public partial class ThuCung
    {
        public string MaTC { get; set; }
        [DisplayName("Tên Thú Cưng")]
        public string TenTC { get; set; }
        [DisplayName("Loài")]
        public string MaLoaiTC { get; set; }
        [DisplayName("Giới Tính")]
        public Nullable<bool> GioiTinh { get; set; }
        [DisplayName("Kích Cỡ")]
        public string KichCo { get; set; }
        [DisplayName("Tiêm Phòng")]
        public Nullable<bool> TiemPhong { get; set; }

        public virtual DoiTuongKD DoiTuongKD { get; set; }
        public virtual LoaiThuCung LoaiThuCung { get; set; }
    }
}
