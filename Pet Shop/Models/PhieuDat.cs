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

    public partial class PhieuDat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuDat()
        {
            this.CT_PhieuDat = new HashSet<CT_PhieuDat>();
        }
        [Display(Name = "Mã phiếu đặt")]
        public string SoPD { get; set; }
        [Display(Name = "Ngày lập")]
        public Nullable<System.DateTime> NgayLap { get; set; }
        [Display(Name = "Số tiền cọc")]
        public Nullable<decimal> SoTienCoc { get; set; }
        [Display(Name = "Hình thức cọc")]
        public string HinhThucCoc { get; set; }
        [Display(Name = "Ngày hẹn giao")]
        public string NgayHen { get; set; }
        [Display(Name = "Mã người dùng")]
        public string IdNguoiDung { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PhieuDat> CT_PhieuDat { get; set; }
    }
}
