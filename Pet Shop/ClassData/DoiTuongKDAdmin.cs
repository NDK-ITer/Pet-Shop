using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Pet_Shop.ClassData
{
    public class DoiTuongKDAdmin
    {
        public string MaDT { get; set; }
        [DisplayName("Đơn giá")]
        public Nullable<decimal> DonGia { get; set; }
        [DisplayName("Trạng thái")]
        public Nullable<bool> TrangThai { get; set; }
        [DisplayName("Giảm giá")]
        public Nullable<decimal> GiamGia { get; set; }
        [DisplayName("Mô tả")]
        public string MoTa { get; set; }
        [DisplayName("Chi tiết")]
        public string ChiTiet { get; set; }
        [DisplayName("Ảnh dại diện")]
        public string AnhDaiDien { get; set; }
    }
}