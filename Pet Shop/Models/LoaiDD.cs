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

    public partial class LoaiDD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiDD()
        {
            this.DoDungTCs = new HashSet<DoDungTC>();
        }
        [DisplayName("Mã loại đồ dùng")]
        public string MaLoaiDD { get; set; }
        [DisplayName("Tên loại đồ dùng")]
        public string TenLoaiDD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoDungTC> DoDungTCs { get; set; }
    }
}
