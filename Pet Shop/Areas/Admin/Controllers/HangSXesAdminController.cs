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
    public class HangSXesAdminController : Controller
    {
        private QuanLyThuCungEntities db = new QuanLyThuCungEntities();

        // GET: Admin/HangSXesAdmin
        public async Task<ActionResult> Index()
        {
            return View(await db.HangSXes.ToListAsync());
        }

        // GET: Admin/HangSXesAdmin/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangSX hangSX = await db.HangSXes.FindAsync(id);
            if (hangSX == null)
            {
                return HttpNotFound();
            }
            return View(hangSX);
        }

        // GET: Admin/HangSXesAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/HangSXesAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaNSX,TenNSX,DiaChi,SuatXu")] HangSX hangSX)
        {
            if (ModelState.IsValid)
            {
                hangSX.MaNSX = Guid.NewGuid().ToString();
                db.HangSXes.Add(hangSX);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(hangSX);
        }

        // GET: Admin/HangSXesAdmin/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangSX hangSX = await db.HangSXes.FindAsync(id);
            if (hangSX == null)
            {
                return HttpNotFound();
            }
            return View(hangSX);
        }

        // POST: Admin/HangSXesAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaNSX,TenNSX,DiaChi,SuatXu")] HangSX hangSX)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hangSX).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(hangSX);
        }

        // GET: Admin/HangSXesAdmin/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangSX hangSX = await db.HangSXes.FindAsync(id);
            if (hangSX == null)
            {
                return HttpNotFound();
            }
            return View(hangSX);
        }

        // POST: Admin/HangSXesAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            HangSX hangSX = await db.HangSXes.FindAsync(id);
            db.HangSXes.Remove(hangSX);
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
