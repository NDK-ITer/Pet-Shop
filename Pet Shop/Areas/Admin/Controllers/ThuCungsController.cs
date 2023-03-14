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

namespace Pet_Shop.Areas.Admin.Controllers
{
    public class ThuCungsController : Controller
    {
        private QuanLyThuCungEntities db = new QuanLyThuCungEntities();

        // GET: Admin/ThuCungs
        public async Task<ActionResult> Index()
        {
            var thuCungs = db.ThuCungs.Include(t => t.DoiTuongKD).Include(t => t.LoaiThuCung);
            return View(await thuCungs.ToListAsync());
        }

        // GET: Admin/ThuCungs/Details/5
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

        // GET: Admin/ThuCungs/Create
        public ActionResult Create()
        {
            ViewBag.MaTC = new SelectList(db.DoiTuongKDs, "MaDT", "MoTa");
            ViewBag.MaLoaiTC = new SelectList(db.LoaiThuCungs, "MaLoaiTC", "TenLoai");
            return View();
        }

        // POST: Admin/ThuCungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaTC,TenTC,MaLoaiTC,GioiTinh,KichCo,TiemPhong")] ThuCung thuCung)
        {
            if (ModelState.IsValid)
            {
                db.ThuCungs.Add(thuCung);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MaTC = new SelectList(db.DoiTuongKDs, "MaDT", "MoTa", thuCung.MaTC);
            ViewBag.MaLoaiTC = new SelectList(db.LoaiThuCungs, "MaLoaiTC", "TenLoai", thuCung.MaLoaiTC);
            return View(thuCung);
        }

        // GET: Admin/ThuCungs/Edit/5
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

        // POST: Admin/ThuCungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaTC,TenTC,MaLoaiTC,GioiTinh,KichCo,TiemPhong")] ThuCung thuCung)
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

        // GET: Admin/ThuCungs/Delete/5
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

        // POST: Admin/ThuCungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            ThuCung thuCung = await db.ThuCungs.FindAsync(id);
            db.ThuCungs.Remove(thuCung);
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
