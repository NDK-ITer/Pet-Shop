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
using System.Data.Entity.Migrations;

namespace Pet_Shop.Controllers
{
    public class GioHangController : Controller
    {
        private QuanLyThuCungEntities dbContext;
        List<GioHang> gioHangs;
        public GioHangController()
        {
            dbContext = new QuanLyThuCungEntities();
        }
        public void LayGiohang(string id)
        {
            gioHangs = dbContext.GioHangs.Where(n => n.Id == id).ToList();
            if (gioHangs == null)
            {
                gioHangs = new List<GioHang>();
            }
        }

        // GET: GioHang
        [Authorize]
        public ActionResult GioHang(int? page, int? pageSize)
        {
            if (page == null) { page = 1; }
            if (pageSize == null) { pageSize = 2; }
            LayGiohang(User.Identity.GetUserId());
            ViewBag.TongSL = TongSL();
            ViewBag.TongThanhTien = TongTien();
            if (gioHangs.Count == 0 || gioHangs == null)
            {
                return View(gioHangs.ToPagedList((int)page, (int)pageSize));
            }

            return View(gioHangs.ToPagedList((int)page, (int)pageSize));
        }
        [Authorize]
        public ActionResult ThemSPVaoGioHang(string id, string strURL)
        {
            LayGiohang(User.Identity.GetUserId());
            GioHang spGioHang = gioHangs.FirstOrDefault(n => n.MaDT == id);
            if (spGioHang != null)
            {
                spGioHang.SoLuong++;
                dbContext.GioHangs.AddOrUpdate(spGioHang);
                dbContext.SaveChanges();
                LayGiohang(User.Identity.GetUserId());
                return Redirect(strURL);
            }
            else if (spGioHang == null)
            {
                spGioHang = new GioHang();
                spGioHang.MaDT = id;
                spGioHang.Id = User.Identity.GetUserId();
                spGioHang.SoLuong = 1;
                dbContext.GioHangs.Add(spGioHang);
                dbContext.SaveChanges();
                LayGiohang(User.Identity.GetUserId());
                return Redirect(strURL);
            }
            return Redirect(strURL);
        }
        [Authorize]
        public ActionResult XoaSPGioHang(string id)
        {
            LayGiohang(User.Identity.GetUserId());
            GioHang sanPham = gioHangs.FirstOrDefault(n => n.MaDT == id);
            if (sanPham != null)
            {
                dbContext.GioHangs.Remove(sanPham);
                dbContext.SaveChanges();
                return RedirectToAction("GioHang");
            }
            return RedirectToAction("GioHang");
        }

        private int TongSL()
        {
            LayGiohang(User.Identity.GetUserId());
            int result = 0;
            if (gioHangs.Count == 0)
            {
                return result;
            }
            foreach (var item in gioHangs)
            {
                result = result + (int)item.SoLuong;
            }
            return result;
        }

        private double TongTien()
        {
            LayGiohang(User.Identity.GetUserId());
            double result = 0;
            if (gioHangs.Count == 0)
            {
                return result;
            }
            foreach (var item in gioHangs)
            {
                DoiTuongKD doiTuongKD = dbContext.DoiTuongKDs.Find(item.MaDT);
                //if (doiTuongKD.GiamGia == 0)
                //{
                //    result = (double)((int)item.SoLuong * (doiTuongKD.DonGia)) + result;
                //    continue;
                //}
                result = (double)((int)item.SoLuong * (doiTuongKD.DonGia-(doiTuongKD.DonGia * doiTuongKD.GiamGia))) + result;
            }
            return result;
        }
    }
}