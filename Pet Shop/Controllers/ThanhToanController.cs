using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Pet_Shop.Models;

namespace Pet_Shop.Controllers
{
    public class ThongTinHoaDon
    {
        public string TenNguoiNhan { get; set; }
        public string DiaChiGiao { get; set; }
        public string SDTNguoiNhan { get; set; }
        public string EmailNguoiNhan { get; set; }
        public string GhiChu { get; set; }
    }
    public class ThanhToanController : Controller
    {
        private QuanLyThuCungEntities dbContext = new QuanLyThuCungEntities();
        List<CT_HoaDon> cT_HoaDons = new List<CT_HoaDon>();
        List<GioHang> = 
        public ActionResult ThanhToan()
        {

            return View();
        }
        [HttpPost]
        public Task<ActionResult> ThanhToan(ThongTinHoaDon thongTinHoaDon)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }

    }
}