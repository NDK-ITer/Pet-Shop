using Pet_Shop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Pet_Shop.ClassData
{
    public class DichVuAdmin:DoiTuongKDAdmin
    {
        [DisplayName("Tên Dịch vụ")]
        public string TenDV { get; set; }
        public virtual DoiTuongKD DoiTuongKD { get; set; }
    }
}