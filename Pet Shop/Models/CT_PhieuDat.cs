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
    
    public partial class CT_PhieuDat
    {
        public string SoPD { get; set; }
        public string MaDT { get; set; }
        public string GhiChu { get; set; }
    
        public virtual PhieuDat PhieuDat { get; set; }
        public virtual DoiTuongKD DoiTuongKD { get; set; }
    }
}
