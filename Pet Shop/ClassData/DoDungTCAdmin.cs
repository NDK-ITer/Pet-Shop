using Pet_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pet_Shop.ClassData
{
    public class DoDungTCAdmin:DoiTuongKDAdmin
    {
        public string MaDD { get; set; }
        public string TenDD { get; set; }
        public string MaLoaiTC { get; set; }
        public string MaNSX { get; set; }
        public virtual HangSX HangSX { get; set; }
        public virtual LoaiThuCung LoaiThuCung { get; set; }
        public virtual DoiTuongKD DoiTuongKD { get; set; }
    }
}