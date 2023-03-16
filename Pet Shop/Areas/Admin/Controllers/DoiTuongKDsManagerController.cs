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
using System.IO;
using Pet_Shop.ClassData;

namespace Pet_Shop.Areas.Admin.Controllers
{
    public class DoiTuongKDsManagerController : Controller
    {
        private QuanLyThuCungEntities db = new QuanLyThuCungEntities();

        // GET: Admin/DoiTuongKDsManager
        public async Task<ActionResult> Index()
        {
            var doiTuongKDs = db.DoiTuongKDs.Include(d => d.DichVu).Include(d => d.DoDungTC).Include(d => d.ThuCung);
            return View(await doiTuongKDs.ToListAsync());
        }

        // GET: Admin/DoiTuongKDsManager/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoiTuongKD doiTuongKD = await db.DoiTuongKDs.FindAsync(id);
            if (doiTuongKD == null)
            {
                return HttpNotFound();
            }
            return View(doiTuongKD);
        }

        // GET: Admin/DoiTuongKDsManager/Create
        public ActionResult Create()
        {
            ViewBag.MaDT = new SelectList(db.DichVus, "MaDV", "TenDV");
            ViewBag.MaDT = new SelectList(db.DoDungTCs, "MaDD", "TenDD");
            ViewBag.MaDT = new SelectList(db.ThuCungs, "MaTC", "TenTC");
            return View();
        }

        // POST: Admin/DoiTuongKDsManager/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaDT,DonGia,TrangThai,GiamGia,MoTa,ChiTiet,AnhDaiDien")] DoiTuongKD doiTuongKD, HttpPostedFileBase anhDaiDien)
        {
            if (ModelState.IsValid)
            {
                doiTuongKD.MaDT = Guid.NewGuid().ToString();
                db.DoiTuongKDs.Add(doiTuongKD);
                await db.SaveChangesAsync();
                if (anhDaiDien != null && anhDaiDien.ContentLength > 0)
                {
                    string fileName = "";
                    fileName = doiTuongKD.MaDT + "avatar";
                    string path = Path.Combine(Server.MapPath("~/Areas/Admin/ImagesProduct"));
                    anhDaiDien.SaveAs(path);
                    DoiTuongKD dtkd = db.DoiTuongKDs.FirstOrDefault(m => m.MaDT == doiTuongKD.MaDT);
                    dtkd.AnhDaiDien = fileName;
                    await db.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }

            ViewBag.MaDT = new SelectList(db.DichVus, "MaDV", "TenDV", doiTuongKD.MaDT);
            ViewBag.MaDT = new SelectList(db.DoDungTCs, "MaDD", "TenDD", doiTuongKD.MaDT);
            ViewBag.MaDT = new SelectList(db.ThuCungs, "MaTC", "TenTC", doiTuongKD.MaDT);
            return View(doiTuongKD);
        }

        public ActionResult CreateThuCung()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateThuCung([Bind(Include = "MaDT,DonGia,TrangThai,GiamGia,MoTa,ChiTiet,AnhDaiDien,MaTC,TenTC,MaLoaiTC,GioiTinh,KichCo,TiemPhong")] DoiTuongKDAdmin doiTuongKDThuCung, HttpPostedFileBase anhDaiDien)
        {
            if (ModelState.IsValid)
            {
                DoiTuongKD doiTuongKD = new DoiTuongKD();
                doiTuongKD.MaDT = Guid.NewGuid().ToString();

                doiTuongKD.DonGia = doiTuongKDThuCung.DonGia;
                doiTuongKD.TrangThai = doiTuongKDThuCung.TrangThai;
                doiTuongKD.GiamGia = doiTuongKDThuCung.GiamGia;
                doiTuongKD.MoTa = doiTuongKDThuCung.MoTa;
                doiTuongKD.ChiTiet = doiTuongKDThuCung.ChiTiet;

                db.DoiTuongKDs.Add(doiTuongKD);
                await db.SaveChangesAsync();
                if (anhDaiDien != null && anhDaiDien.ContentLength > 0)
                {
                    string fileName = "";
                    fileName = doiTuongKD.MaDT + "avatar";
                    string path = Path.Combine(Server.MapPath("~/Areas/Admin/ImagesProduct"));
                    anhDaiDien.SaveAs(path);
                    DoiTuongKD dtkd = db.DoiTuongKDs.FirstOrDefault(m => m.MaDT == doiTuongKD.MaDT);
                    dtkd.AnhDaiDien = fileName;
                    await db.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }
            return View(doiTuongKDThuCung);
        }

        // GET: Admin/DoiTuongKDsManager/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoiTuongKD doiTuongKD = await db.DoiTuongKDs.FindAsync(id);
            if (doiTuongKD == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDT = new SelectList(db.DichVus, "MaDV", "TenDV", doiTuongKD.MaDT);
            ViewBag.MaDT = new SelectList(db.DoDungTCs, "MaDD", "TenDD", doiTuongKD.MaDT);
            ViewBag.MaDT = new SelectList(db.ThuCungs, "MaTC", "TenTC", doiTuongKD.MaDT);
            return View(doiTuongKD);
        }

        // POST: Admin/DoiTuongKDsManager/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaDT,DonGia,TrangThai,GiamGia,MoTa,ChiTiet,AnhDaiDien")] DoiTuongKD doiTuongKD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doiTuongKD).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MaDT = new SelectList(db.DichVus, "MaDV", "TenDV", doiTuongKD.MaDT);
            ViewBag.MaDT = new SelectList(db.DoDungTCs, "MaDD", "TenDD", doiTuongKD.MaDT);
            ViewBag.MaDT = new SelectList(db.ThuCungs, "MaTC", "TenTC", doiTuongKD.MaDT);
            return View(doiTuongKD);
        }

        // GET: Admin/DoiTuongKDsManager/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoiTuongKD doiTuongKD = await db.DoiTuongKDs.FindAsync(id);
            if (doiTuongKD == null)
            {
                return HttpNotFound();
            }
            return View(doiTuongKD);
        }

        // POST: Admin/DoiTuongKDsManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            DoiTuongKD doiTuongKD = await db.DoiTuongKDs.FindAsync(id);
            db.DoiTuongKDs.Remove(doiTuongKD);
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
