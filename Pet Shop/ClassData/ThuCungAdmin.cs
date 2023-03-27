using Pet_Shop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pet_Shop.ClassData
{
    public class ThuCungAdmin:DoiTuongKDAdmin
    {
        //public ThuCungAdmin()
        //{
        //    AnhDaiDien = "~/ImagesProduct/petChose.png";
        //}
        public string MaTC { get; set; }
        [DisplayName("Tên Thú Cưng")]
        public string TenTC { get; set; }
        [DisplayName("Loài")]
        public string MaLoaiTC { get; set; }
        [DisplayName("Giới Tính")]
        public Nullable<bool> GioiTinh { get; set; }
        [DisplayName("Kích Cỡ")]
        public string KichCo { get; set; }
        [DisplayName("Tiêm Phòng")]
        public Nullable<bool> TiemPhong { get; set; }
        public virtual LoaiThuCung LoaiThuCung { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImgUpLoad { get; set; }
    }
}