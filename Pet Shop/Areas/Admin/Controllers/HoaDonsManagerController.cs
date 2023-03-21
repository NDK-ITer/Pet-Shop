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
    public class HoaDonsManagerController : Controller
    {
        private QuanLyThuCungEntities db = new QuanLyThuCungEntities();

        // GET: Admin/HoaDonsManager
        public async Task<ActionResult> Index()
        {
            var hoaDons = db.HoaDons.Include(h => h.NhanSU);
            return View(await hoaDons.ToListAsync());
        }

        // GET: Admin/HoaDonsManager/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = await db.HoaDons.FindAsync(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // GET: Admin/HoaDonsManager/Create
        public ActionResult Create()
        {
            ViewBag.MaNS = new SelectList(db.NhanSUs, "MaNS", "TenNS");
            return View();
        }

        // POST: Admin/HoaDonsManager/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SoHD,NgayLap,TongThanhTien,MaNS,TenKH,DiaChi,IdNguoiDung")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                hoaDon.SoHD = Guid.NewGuid().ToString();
                db.HoaDons.Add(hoaDon);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MaNS = new SelectList(db.NhanSUs, "MaNS", "TenNS", hoaDon.MaNS);
            return View(hoaDon);
        }

        // GET: Admin/HoaDonsManager/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = await db.HoaDons.FindAsync(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNS = new SelectList(db.NhanSUs, "MaNS", "TenNS", hoaDon.MaNS);
            return View(hoaDon);
        }

        // POST: Admin/HoaDonsManager/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SoHD,NgayLap,TongThanhTien,MaNS,TenKH,DiaChi,IdNguoiDung")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MaNS = new SelectList(db.NhanSUs, "MaNS", "TenNS", hoaDon.MaNS);
            return View(hoaDon);
        }

        // GET: Admin/HoaDonsManager/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = await db.HoaDons.FindAsync(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: Admin/HoaDonsManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            HoaDon hoaDon = await db.HoaDons.FindAsync(id);
            db.HoaDons.Remove(hoaDon);
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
