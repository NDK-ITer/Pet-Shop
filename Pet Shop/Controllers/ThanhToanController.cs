using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Pet_Shop.Models;
using PagedList;

namespace Pet_Shop.Controllers
{
    public class ThanhToanController : Controller
    {
        private QuanLyThuCungEntities dbContext = new QuanLyThuCungEntities();
        private HoaDon hoaDon = new HoaDon();
        public ActionResult LapHoaDon()
        {
            if (Request.IsAuthenticated)
            {
                hoaDon.TenNguoiNhan = User.Identity.GetUserName();
            }
            hoaDon.NgayLap = DateTime.Now.ToString();
            return View(hoaDon);
        }

        [HttpPost]
        public ActionResult LapHoaDon(HoaDon thongTinHoaDon)
        {
            List<CT_HoaDon> cT_HoaDons = LayDsSPMua();
            if (ModelState.IsValid)
            {
                if (Request.IsAuthenticated)
                {
                    hoaDon.IdNguoiDung = User.Identity.GetUserId();
                }
                hoaDon.SoHD = Guid.NewGuid().ToString();
                hoaDon.NgayLap = thongTinHoaDon.NgayLap;
                hoaDon.TongThanhTien = cT_HoaDons.Sum(n => n.ThanhTien);
                hoaDon.TenNguoiNhan = thongTinHoaDon.TenNguoiNhan;
                hoaDon.DiaChiGiao = thongTinHoaDon.DiaChiGiao;
                hoaDon.SDTNguoiNhan = thongTinHoaDon.SDTNguoiNhan;
                hoaDon.EmailNguoiNhan = thongTinHoaDon.EmailNguoiNhan;
                hoaDon.GhiChu = thongTinHoaDon.GhiChu;
                dbContext.HoaDons.Add(hoaDon);
                dbContext.SaveChanges();
                foreach (var item in cT_HoaDons)
                {
                    item.SoHD = hoaDon.SoHD;
                    dbContext.CT_HoaDon.Add(item);
                    dbContext.SaveChanges();
                }
            }
            return View();
        }

        public List<CT_HoaDon> LayDsSPMua()
        {
            List<CT_HoaDon> cT_HoaDons = Session["DsSPMua"] as List<CT_HoaDon>;
            if (cT_HoaDons == null)
            {
                cT_HoaDons = new List<CT_HoaDon>();
                Session["DsSPMua"] = cT_HoaDons;
            }
            return cT_HoaDons;
        }
        public ActionResult DsSPMua(int? page, int? pageSize)
        {
            List<CT_HoaDon> cT_HoaDons = LayDsSPMua();
            if (page == null) { page = 1; }
            if (pageSize == null) { pageSize = 2; }
            ViewBag.TongSL = TongSL();
            ViewBag.TongThanhTien = TongTien();
            if (cT_HoaDons.Count == 0 || cT_HoaDons == null)
            {
                return View(cT_HoaDons.ToPagedList((int)page, (int)pageSize));
            }
            return View(cT_HoaDons.ToPagedList((int)page, (int)pageSize));
        }

        public int TongSL()
        {
            List<CT_HoaDon> cT_HoaDons = LayDsSPMua();
            int result = 0;
            if (cT_HoaDons.Count == 0)
            {
                return result;
            }
            foreach (var item in cT_HoaDons)
            {
                result = result + (int)item.SoLuong;
            }
            return result;
        }

        public double TongTien()
        {
            List<CT_HoaDon> cT_HoaDons = LayDsSPMua();
            double result = 0;
            if (cT_HoaDons.Count == 0)
            {
                return result;
            }
            foreach (var item in cT_HoaDons)
            {
                result = result + (double)item.ThanhTien;
            }
            return result;
        }

        public ActionResult MuaSP(string id)
        {
            List<CT_HoaDon> cT_HoaDons = LayDsSPMua();
            DoiTuongKD doiTuongKD = dbContext.DoiTuongKDs.FirstOrDefault(n => n.MaDT == id);
            CT_HoaDon sanPham = cT_HoaDons.FirstOrDefault(n => n.MaDT == id);
            if (sanPham != null)
            {
                sanPham.SoLuong++;
                if (doiTuongKD.GiamGia != 0)
                {
                    sanPham.ThanhTien = sanPham.SoLuong * (doiTuongKD.DonGia * doiTuongKD.GiamGia);
                }
                sanPham.ThanhTien = sanPham.SoLuong * (sanPham.DoiTuongKD.DonGia);
                return RedirectToAction("LapHoaDon");
            }
            sanPham = new CT_HoaDon();
            sanPham.MaDT = id;
            sanPham.SoLuong = 1;
            sanPham.DoiTuongKD = doiTuongKD;
            //if (doiTuongKD.GiamGia != 0)
            //{
            //    sanPham.ThanhTien = sanPham.SoLuong * (doiTuongKD.DonGia * doiTuongKD.GiamGia);
            //}
            sanPham.ThanhTien = sanPham.SoLuong * (doiTuongKD.DonGia-(doiTuongKD.DonGia * doiTuongKD.GiamGia));
            cT_HoaDons.Add(sanPham);
            return RedirectToAction("LapHoaDon");
        }

        public ActionResult XoaSP(string id)
        {
            List<CT_HoaDon> cT_HoaDons = LayDsSPMua();
            CT_HoaDon cT_HoaDon = cT_HoaDons.FirstOrDefault(n => n.MaDT == id);
            if (cT_HoaDon != null)
            {
                cT_HoaDons.Remove(cT_HoaDon);
            }
            return RedirectToAction("LapHoaDon");
        }
        [Authorize]
        public ActionResult ThemSPGioHang(string id)
        {
            if (Request.IsAuthenticated)
            {
                List<CT_HoaDon> cT_HoaDons = LayDsSPMua();
                List<GioHang> gioHangs = dbContext.GioHangs.Where(n => n.Id == id).ToList();
                foreach (var item in gioHangs)
                {
                    CT_HoaDon newItem = cT_HoaDons.FirstOrDefault(n => n.MaDT == item.MaDT);
                    if (newItem != null)
                    {
                        newItem.SoLuong = newItem.SoLuong + item.SoLuong;
                        if (item.DoiTuongKD.GiamGia != 0)
                        {
                            newItem.ThanhTien = item.SoLuong * (item.DoiTuongKD.DonGia * item.DoiTuongKD.GiamGia);
                        }
                        continue;
                    }
                    newItem = new CT_HoaDon();
                    newItem.DoiTuongKD = item.DoiTuongKD;
                    newItem.MaDT = item.MaDT;
                    newItem.SoLuong = item.SoLuong;
                    //if (item.DoiTuongKD.GiamGia != 0)
                    //{
                    //    newItem.ThanhTien = item.SoLuong * (item.DoiTuongKD.DonGia * item.DoiTuongKD.GiamGia);
                    //}
                    newItem.ThanhTien = item.SoLuong * (item.DoiTuongKD.DonGia-(item.DoiTuongKD.DonGia * item.DoiTuongKD.GiamGia));
                    cT_HoaDons.Add(newItem);
                }
                return RedirectToAction("LapHoaDon");
            }
            return RedirectToAction("LapHoaDon");
        }

    }
}