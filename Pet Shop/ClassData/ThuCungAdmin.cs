using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pet_Shop.ClassData
{
    public class ThuCungAdmin:DoiTuongKDAdmin
    {
        public string MaTC { get; set; }
        public string TenTC { get; set; }
        public string MaLoaiTC { get; set; }
        public Nullable<int> GioiTinh { get; set; }
        public string KichCo { get; set; }
        public Nullable<int> TiemPhong { get; set; }
    }
}