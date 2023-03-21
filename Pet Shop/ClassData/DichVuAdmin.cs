using Pet_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pet_Shop.ClassData
{
    public class DichVuAdmin:DoiTuongKDAdmin
    {
        public string MaDV { get; set; }
        public string TenDV { get; set; }
        public virtual DoiTuongKD DoiTuongKD { get; set; }
    }
}