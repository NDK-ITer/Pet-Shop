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
using System.Data;
using System.IO;

namespace Pet_Shop.Areas.Admin.Controllers
{
    public class ThuCungsAdminController : Controller
    {
        private QuanLyThuCungEntities db = new QuanLyThuCungEntities();

        // GET: Admin/ThuCungsAdmin
        public async Task<ActionResult> Index()
        {
            var thuCungs = db.ThuCungs.Include(t => t.DoiTuongKD).Include(t => t.LoaiThuCung);
            return View(await thuCungs.ToListAsync());
        }

        // GET: Admin/ThuCungsAdmin/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThuCung thuCung = await db.ThuCungs.FindAsync(id);
            if (thuCung == null)
            {
                return HttpNotFound();
            }
            return View(thuCung);
        }

        // GET: Admin/ThuCungsAdmin/Create
        public ActionResult Create()
        {
            ThuCungAdmin thuCungAdmin = new ThuCungAdmin();
            ViewBag.MaTC = new SelectList(db.DoiTuongKDs, "MaDT", "MoTa");
            ViewBag.MaLoaiTC = new SelectList(db.LoaiThuCungs, "MaLoaiTC", "TenLoai");
            return View(thuCungAdmin);
        }

        // POST: Admin/ThuCungsAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ThuCungAdmin thuCungAdmin, HttpPostedFileBase Content)
        {
            ThuCung thuCung = new ThuCung();
            DoiTuongKD doiTuongKD = new DoiTuongKD();
            if (ModelState.IsValid)
            {

                if (Content != null && Content.ContentLength > 0)
                {
                    //var typeFile = Path.GetExtension(Content.FileName);
                    //thuCungAdmin.AnhDaiDien = thuCungAdmin.MaDT + typeFile;
                    //var filePath = Path.Combine(Server.MapPath("~/ImagesProduct/ThuCung/"), thuCungAdmin.AnhDaiDien);
                    //Content.SaveAs(filePath);
                    string fileName = Path.GetFileNameWithoutExtension(Content.FileName);
                    string extention = Path.GetExtension(thuCungAdmin.ImgUpLoad.FileName);
                    fileName = fileName + extention;
                    thuCungAdmin.AnhDaiDien = "~/ImagesProduct/ThuCung/" + fileName;
                    thuCungAdmin.ImgUpLoad.SaveAs(Path.Combine(Server.MapPath("~/ImagesProduct/ThuCung/"), fileName));
                }
                doiTuongKD.MaDT = Guid.NewGuid().ToString();
                doiTuongKD.DonGia = thuCungAdmin.DonGia;
                doiTuongKD.TrangThai = thuCungAdmin.TrangThai;
                doiTuongKD.GiamGia = thuCungAdmin.GiamGia;
                doiTuongKD.MoTa = thuCungAdmin.MoTa;
                doiTuongKD.ChiTiet = thuCungAdmin.ChiTiet;
                doiTuongKD.AnhDaiDien = thuCungAdmin.AnhDaiDien;
                db.DoiTuongKDs.Add(doiTuongKD);
                await db.SaveChangesAsync();
                thuCung.MaTC = doiTuongKD.MaDT;
                thuCung.TenTC = thuCungAdmin.TenTC;
                thuCung.MaLoaiTC = thuCungAdmin.MaLoaiTC;
                thuCung.GioiTinh = thuCungAdmin.GioiTinh;
                thuCung.KichCo = thuCungAdmin.KichCo;
                thuCung.TiemPhong = thuCungAdmin.TiemPhong;
                
                db.ThuCungs.Add(thuCung);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MaTC = new SelectList(db.DoiTuongKDs, "MaDT", "MoTa", thuCung.MaTC);
            ViewBag.MaLoaiTC = new SelectList(db.LoaiThuCungs, "MaLoaiTC", "TenLoai", thuCung.MaLoaiTC);
            return View(thuCung);
        }

        // GET: Admin/ThuCungsAdmin/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThuCung thuCung = await db.ThuCungs.FindAsync(id);
            if (thuCung == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaTC = new SelectList(db.DoiTuongKDs, "MaDT", "MoTa", thuCung.MaTC);
            ViewBag.MaLoaiTC = new SelectList(db.LoaiThuCungs, "MaLoaiTC", "TenLoai", thuCung.MaLoaiTC);
            return View(thuCung);
        }

        // POST: Admin/ThuCungsAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ThuCung thuCung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thuCung).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MaTC = new SelectList(db.DoiTuongKDs, "MaDT", "MoTa", thuCung.MaTC);
            ViewBag.MaLoaiTC = new SelectList(db.LoaiThuCungs, "MaLoaiTC", "TenLoai", thuCung.MaLoaiTC);
            return View(thuCung);
        }

        // GET: Admin/ThuCungsAdmin/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThuCung thuCung = await db.ThuCungs.FindAsync(id);
            if (thuCung == null)
            {
                return HttpNotFound();
            }
            return View(thuCung);
        }

        // POST: Admin/ThuCungsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            DoiTuongKD thuCungDelete = db.DoiTuongKDs.Find(id);
            ThuCung thuCung = await db.ThuCungs.FindAsync(id);
            db.ThuCungs.Remove(thuCung);
            await db.SaveChangesAsync();
            db.DoiTuongKDs.Remove(thuCungDelete);
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
