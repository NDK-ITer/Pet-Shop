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
    public class PhieuDatsManagerController : Controller
    {
        private QuanLyThuCungEntities db = new QuanLyThuCungEntities();

        // GET: Admin/PhieuDatsManager
        public async Task<ActionResult> Index()
        {
            return View(await db.PhieuDats.ToListAsync());
        }

        // GET: Admin/PhieuDatsManager/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuDat phieuDat = await db.PhieuDats.FindAsync(id);
            if (phieuDat == null)
            {
                return HttpNotFound();
            }
            return View(phieuDat);
        }

        // GET: Admin/PhieuDatsManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PhieuDatsManager/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SoPD,NgayLap,SoTienCoc,HinhThucCoc,NgayHen,IdNguoiDung")] PhieuDat phieuDat)
        {
            if (ModelState.IsValid)
            {
                phieuDat.SoPD = Guid.NewGuid().ToString();
                db.PhieuDats.Add(phieuDat);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(phieuDat);
        }

        // GET: Admin/PhieuDatsManager/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuDat phieuDat = await db.PhieuDats.FindAsync(id);
            if (phieuDat == null)
            {
                return HttpNotFound();
            }
            return View(phieuDat);
        }

        // POST: Admin/PhieuDatsManager/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SoPD,NgayLap,SoTienCoc,HinhThucCoc,NgayHen,IdNguoiDung")] PhieuDat phieuDat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuDat).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(phieuDat);
        }

        // GET: Admin/PhieuDatsManager/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuDat phieuDat = await db.PhieuDats.FindAsync(id);
            if (phieuDat == null)
            {
                return HttpNotFound();
            }
            return View(phieuDat);
        }

        // POST: Admin/PhieuDatsManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            PhieuDat phieuDat = await db.PhieuDats.FindAsync(id);
            db.PhieuDats.Remove(phieuDat);
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
