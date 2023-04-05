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
    public class ThanhToanController : Controller
    {
        private QuanLyThuCungEntities dbContext = new QuanLyThuCungEntities();
        List<CT_HoaDon> cT_HoaDons = new List<CT_HoaDon>();
        private HoaDon hoaDon = new HoaDon();
        public ActionResult ThanhToan()
        {
            return View(hoaDon);
        }
        //[HttpPost]
        //public Task<ActionResult> ThanhToan(ThongTinHoaDon thongTinHoaDon)
        //{
        //    if (ModelState.IsValid)
        //    {

        //    }
        //    return View();
        //}

    }
}