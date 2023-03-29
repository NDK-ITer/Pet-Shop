using Pet_Shop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Pet_Shop.ClassData
{
    public class DoDungTCAdmin:DoiTuongKDAdmin
    {
        public string MaDD { get; set; }
        [DisplayName("Tên đồ dùng")]
        public string TenDD { get; set; }
        [DisplayName("Loài")]
        public string MaLoaiTC { get; set; }
        [DisplayName("Hãng sản xuất")]
        public string MaNSX { get; set; }
        [DisplayName("Loại đồ dùng")]
        public string MaLoaiDD { get; set; }
        public virtual HangSX HangSX { get; set; }
        public virtual LoaiThuCung LoaiThuCung { get; set; }
        public virtual DoiTuongKD DoiTuongKD { get; set; }
        public virtual LoaiDD LoaiDD { get; set; }
    }
}