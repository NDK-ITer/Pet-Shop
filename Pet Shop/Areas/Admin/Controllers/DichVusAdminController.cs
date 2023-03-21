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

namespace Pet_Shop.Areas.Admin.Controllers
{
    public class DichVusAdminController : Controller
    {
        private QuanLyThuCungEntities db = new QuanLyThuCungEntities();

        // GET: Admin/DichVusAdmin
        public async Task<ActionResult> Index()
        {
            var dichVus = db.DichVus.Include(d => d.DoiTuongKD);
            return View(await dichVus.ToListAsync());
        }

        // GET: Admin/DichVusAdmin/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DichVu dichVu = await db.DichVus.FindAsync(id);
            if (dichVu == null)
            {
                return HttpNotFound();
            }
            return View(dichVu);
        }

        // GET: Admin/DichVusAdmin/Create
        public ActionResult Create()
        {
            ViewBag.MaDV = new SelectList(db.DoiTuongKDs, "MaDT", "MoTa");
            return View();
        }

        // POST: Admin/DichVusAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaDV,TenDV")] DichVuAdmin dichVuAdmin)
        {
            DichVu dichVu = new DichVu();
            DoiTuongKD doiTuongKD = new DoiTuongKD();
            if (ModelState.IsValid)
            {
                doiTuongKD.MaDT = Guid.NewGuid().ToString();
                doiTuongKD.DonGia = dichVuAdmin.DonGia;
                doiTuongKD.TrangThai = dichVuAdmin.TrangThai;
                doiTuongKD.GiamGia = dichVuAdmin.GiamGia;
                doiTuongKD.MoTa = dichVuAdmin.MoTa;
                doiTuongKD.ChiTiet = dichVuAdmin.ChiTiet;
                db.DoiTuongKDs.Add(doiTuongKD);
                await db.SaveChangesAsync();

                dichVu.MaDV = doiTuongKD.MaDT;
                dichVu.TenDV = dichVuAdmin.TenDV;
                db.DichVus.Add(dichVu);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MaDV = new SelectList(db.DoiTuongKDs, "MaDT", "MoTa", dichVu.MaDV);
            return View(dichVu);
        }

        // GET: Admin/DichVusAdmin/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DichVu dichVu = await db.DichVus.FindAsync(id);
            if (dichVu == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDV = new SelectList(db.DoiTuongKDs, "MaDT", "MoTa", dichVu.MaDV);
            return View(dichVu);
        }

        // POST: Admin/DichVusAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaDV,TenDV")] DichVu dichVu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dichVu).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MaDV = new SelectList(db.DoiTuongKDs, "MaDT", "MoTa", dichVu.MaDV);
            return View(dichVu);
        }

        // GET: Admin/DichVusAdmin/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DichVu dichVu = await db.DichVus.FindAsync(id);
            if (dichVu == null)
            {
                return HttpNotFound();
            }
            return View(dichVu);
        }

        // POST: Admin/DichVusAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            DichVu dichVu = await db.DichVus.FindAsync(id);
            db.DichVus.Remove(dichVu);
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
