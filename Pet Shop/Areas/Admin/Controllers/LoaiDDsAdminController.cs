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
    public class LoaiDDsAdminController : Controller
    {
        private QuanLyThuCungEntities db = new QuanLyThuCungEntities();

        // GET: Admin/LoaiDDsAdmin
        public async Task<ActionResult> Index()
        {
            return View(await db.LoaiDDs.ToListAsync());
        }

        // GET: Admin/LoaiDDsAdmin/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiDD loaiDD = await db.LoaiDDs.FindAsync(id);
            if (loaiDD == null)
            {
                return HttpNotFound();
            }
            return View(loaiDD);
        }

        // GET: Admin/LoaiDDsAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiDDsAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LoaiDD loaiDD)
        {
            if (ModelState.IsValid)
            {
                db.LoaiDDs.Add(loaiDD);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(loaiDD);
        }

        // GET: Admin/LoaiDDsAdmin/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiDD loaiDD = await db.LoaiDDs.FindAsync(id);
            if (loaiDD == null)
            {
                return HttpNotFound();
            }
            return View(loaiDD);
        }

        // POST: Admin/LoaiDDsAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaLoaiDD,TenLoaiDD")] LoaiDD loaiDD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiDD).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(loaiDD);
        }

        // GET: Admin/LoaiDDsAdmin/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiDD loaiDD = await db.LoaiDDs.FindAsync(id);
            if (loaiDD == null)
            {
                return HttpNotFound();
            }
            return View(loaiDD);
        }

        // POST: Admin/LoaiDDsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            LoaiDD loaiDD = await db.LoaiDDs.FindAsync(id);
            db.LoaiDDs.Remove(loaiDD);
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
