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
    using System.ComponentModel.DataAnnotations;

    public partial class ThuCung
    {
        [Display(Name = "Mã thú cưng")]
        public string MaTC { get; set; }
        [Display(Name = "Tên thú cưng")]
        public string TenTC { get; set; }
        [Display(Name = "Mã loại thú cưng")]
        public string MaLoaiTC { get; set; }
        [Display(Name = "Giới tính")]
        public Nullable<bool> GioiTinh { get; set; }
        [Display(Name = "Kích cở")]
        public string KichCo { get; set; }
        [Display(Name = "Tiêm phòng")]
        public Nullable<bool> TiemPhong { get; set; }
    
        public virtual DoiTuongKD DoiTuongKD { get; set; }
        public virtual LoaiThuCung LoaiThuCung { get; set; }
    }
}
