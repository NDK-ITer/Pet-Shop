using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pet_Shop.Models;
using Pet_Shop.ClassData;
using System.IO;
using PagedList;

namespace Pet_Shop.Areas.Admin.Controllers
{
    public class DoDungTCsAdminController : Controller
    {
        private QuanLyThuCungEntities db = new QuanLyThuCungEntities();

        // GET: Admin/DoDungTCsAdmin
        public async Task<ActionResult> Index(int? page, int? pageSize)
        {
            if (page == null) { page = 1; }
            if (pageSize == null) { pageSize = 5; }
            var doDungTC = db.DoDungTCs.ToList();
            return View(doDungTC.ToPagedList((int)page, (int)pageSize));
        }

        // GET: Admin/DoDungTCsAdmin/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoDungTC doDungTC = await db.DoDungTCs.FindAsync(id);
            if (doDungTC == null)
            {
                return HttpNotFound();
            }
            return View(doDungTC);
        }

        // GET: Admin/DoDungTCsAdmin/Create
        public ActionResult Create()
        {
            ViewBag.MaNSX = new SelectList(db.HangSXes, "MaNSX", "TenNSX");
            ViewBag.MaLoaiTC = new SelectList(db.LoaiThuCungs, "MaLoaiTC", "TenLoai");
            ViewBag.MaDD = new SelectList(db.DoiTuongKDs, "MaDT", "MoTa");
            ViewBag.MaLoaiDD = new SelectList(db.LoaiDDs, "MaLoaiDD", "TenLoaiDD");
            return View();
        }

        // POST: Admin/DoDungTCsAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DoDungTCAdmin doDungTCAdmin, HttpPostedFileBase file)
        {
            DoDungTC doDungTC = new DoDungTC();
            DoiTuongKD doiTuongKD = new DoiTuongKD();
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    string extention = Path.GetExtension(file.FileName);
                    fileName = fileName + extention;
                    doDungTCAdmin.AnhDaiDien = "~/ImagesProduct/DoDung/" + fileName;
                    file.SaveAs(Path.Combine(Server.MapPath("~/ImagesProduct/DoDung/"), fileName));
                }

                doiTuongKD.MaDT = Guid.NewGuid().ToString();
                doiTuongKD.DonGia = doDungTCAdmin.DonGia;
                doiTuongKD.TrangThai = doDungTCAdmin.TrangThai;
                doiTuongKD.GiamGia = doDungTCAdmin.GiamGia;
                doiTuongKD.MoTa = doDungTCAdmin.MoTa;
                doiTuongKD.ChiTiet = doDungTCAdmin.ChiTiet;
                doiTuongKD.AnhDaiDien = doDungTCAdmin.AnhDaiDien;
                db.DoiTuongKDs.Add(doiTuongKD);
                await db.SaveChangesAsync();

                doDungTC.MaDD = doiTuongKD.MaDT;
                doDungTC.TenDD = doDungTCAdmin.TenDD;
                doDungTC.MaNSX = doDungTCAdmin.MaNSX;
                doDungTC.MaLoaiTC = doDungTCAdmin.MaLoaiTC;
                doDungTC.SoLuong = doDungTCAdmin.SoLuong;
                db.DoDungTCs.Add(doDungTC);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MaNSX = new SelectList(db.HangSXes, "MaNSX", "TenNSX", doDungTC.MaNSX);
            ViewBag.MaLoaiTC = new SelectList(db.LoaiThuCungs, "MaLoaiTC", "TenLoai", doDungTC.MaLoaiTC);
            ViewBag.MaDD = new SelectList(db.DoiTuongKDs, "MaDT", "MoTa", doDungTC.MaDD);
            return View(doDungTC);
        }

        // GET: Admin/DoDungTCsAdmin/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoDungTC doDungTC = await db.DoDungTCs.FindAsync(id);
            if (doDungTC == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNSX = new SelectList(db.HangSXes, "MaNSX", "TenNSX", doDungTC.MaNSX);
            ViewBag.MaLoaiTC = new SelectList(db.LoaiThuCungs, "MaLoaiTC", "TenLoai", doDungTC.MaLoaiTC);
            ViewBag.MaDD = new SelectList(db.DoiTuongKDs, "MaDT", "MoTa", doDungTC.MaDD);
            return View(doDungTC);
        }

        // POST: Admin/DoDungTCsAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(DoDungTC doDungTC, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    string extention = Path.GetExtension(file.FileName);
                    fileName = fileName + extention;
                    doDungTC.DoiTuongKD.AnhDaiDien = "~/ImagesProduct/DoDung/" + fileName;
                    file.SaveAs(Path.Combine(Server.MapPath("~/ImagesProduct/DoDung/"), fileName));
                }
                db.Entry(doDungTC).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MaNSX = new SelectList(db.HangSXes, "MaNSX", "TenNSX", doDungTC.MaNSX);
            ViewBag.MaLoaiTC = new SelectList(db.LoaiThuCungs, "MaLoaiTC", "TenLoai", doDungTC.MaLoaiTC);
            ViewBag.MaDD = new SelectList(db.DoiTuongKDs, "MaDT", "MoTa", doDungTC.MaDD);
            return View(doDungTC);
        }

        // GET: Admin/DoDungTCsAdmin/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoDungTC doDungTC = await db.DoDungTCs.FindAsync(id);
            if (doDungTC == null)
            {
                return HttpNotFound();
            }
            return View(doDungTC);
        }

        // POST: Admin/DoDungTCsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            DoDungTC doDungTC = await db.DoDungTCs.FindAsync(id);
            db.DoDungTCs.Remove(doDungTC);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
