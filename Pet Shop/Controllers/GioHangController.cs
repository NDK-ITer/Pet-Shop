using Microsoft.Ajax.Utilities;
using Pet_Shop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using PagedList;
using Microsoft.AspNet.Identity;

namespace Pet_Shop.Controllers
{
    public class GioHangController : Controller
    {
        private QuanLyThuCungEntities dbContext ;
        List<GioHang> GioHangs = new List<GioHang>();
        public GioHangController()
        {
            dbContext = new QuanLyThuCungEntities();
        }
        public List<SPGioHang> LayGiohang()
        {
            List<SPGioHang> gioHangs = Session["GioHang"] as List<SPGioHang>;
            if (gioHangs == null)
            {
                gioHangs = new List<SPGioHang>();
                Session["GioHang"] = gioHangs;
            }
            return gioHangs;
        }

        // GET: GioHang
        //[Authorize]
        public ActionResult GioHang(int? page, int? pageSize)
        {
            if (page == null) { page = 1; }
            if (pageSize == null) { pageSize = 2; }
            List<SPGioHang> gioHangs = LayGiohang();
            ViewBag.TongSL = TongSL();
            ViewBag.TongThanhTien = TongTien();
            if (gioHangs.Count == 0)
            {
                return View(gioHangs.ToPagedList((int)page, (int)pageSize));
            }
            
            return View(gioHangs.ToPagedList((int)page, (int)pageSize));
        }

        public ActionResult ThemVaoGioHang(string id, string strURL)
        {
            List<SPGioHang> gioHangs = LayGiohang();
            var sanPham = gioHangs.FirstOrDefault(n => n.MaDD == id);
            if (sanPham == null)
            {
                sanPham = new SPGioHang(id);
                gioHangs.Add(sanPham);
                return Redirect(strURL);
            }
            else
            {
                sanPham.SoLuong++;
                return Redirect(strURL);
            }
        }

        public ActionResult XoaGioHang(string id)
        {
            List<SPGioHang> gioHangs = LayGiohang();
            SPGioHang sanPham = gioHangs.FirstOrDefault(n => n.MaDD == id);
            if (sanPham != null)
            {
                gioHangs.Remove(sanPham);
                return RedirectToAction("GioHang");
            }
            return RedirectToAction("GioHang");
        }

        private int TongSL()
        {
            int result = 0;
            List<SPGioHang> gioHangs = LayGiohang();
            if (gioHangs == null)
            
            {
                return result;
            }
            return gioHangs.Count;
        }

        private double TongTien()
        {
            double result = 0;
            List<SPGioHang> gioHangs = LayGiohang();
            if (gioHangs.Count > 0)
            {
                result = gioHangs.Sum(n => n.ThanhTien);
                return result;
            }
            return result;
        }
    }
}