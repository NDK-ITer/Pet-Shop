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
    public class LoaiThuCungsManagerController : Controller
    {
        private QuanLyThuCungEntities db = new QuanLyThuCungEntities();

        // GET: Admin/LoaiThuCungsManager
        public async Task<ActionResult> Index()
        {
            return View(await db.LoaiThuCungs.ToListAsync());
        }

        // GET: Admin/LoaiThuCungsManager/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiThuCung loaiThuCung = await db.LoaiThuCungs.FindAsync(id);
            if (loaiThuCung == null)
            {
                return HttpNotFound();
            }
            return View(loaiThuCung);
        }

        // GET: Admin/LoaiThuCungsManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiThuCungsManager/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaLoaiTC,TenLoai")] LoaiThuCung loaiThuCung)
        {
            if (ModelState.IsValid)
            {
                loaiThuCung.MaLoaiTC = Guid.NewGuid().ToString();
                db.LoaiThuCungs.Add(loaiThuCung);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(loaiThuCung);
        }

        // GET: Admin/LoaiThuCungsManager/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiThuCung loaiThuCung = await db.LoaiThuCungs.FindAsync(id);
            if (loaiThuCung == null)
            {
                return HttpNotFound();
            }
            return View(loaiThuCung);
        }

        // POST: Admin/LoaiThuCungsManager/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaLoaiTC,TenLoai")] LoaiThuCung loaiThuCung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiThuCung).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(loaiThuCung);
        }

        // GET: Admin/LoaiThuCungsManager/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiThuCung loaiThuCung = await db.LoaiThuCungs.FindAsync(id);
            if (loaiThuCung == null)
            {
                return HttpNotFound();
            }
            return View(loaiThuCung);
        }

        // POST: Admin/LoaiThuCungsManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            LoaiThuCung loaiThuCung = await db.LoaiThuCungs.FindAsync(id);
            db.LoaiThuCungs.Remove(loaiThuCung);
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
