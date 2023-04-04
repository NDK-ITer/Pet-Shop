﻿using Pet_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Net;
using System.Threading.Tasks;

namespace Pet_Shop.Controllers
{
    public class HomeController : Controller
    {
        private static QuanLyThuCungEntities dbContext = new QuanLyThuCungEntities();
        List<DoiTuongKD> doiTuongKDs = dbContext.DoiTuongKDs.ToList();
        List<DichVu> dichVus = dbContext.DichVus.ToList();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DichVu(int? page, int? pageSize)
        {
            if (page == null) { page = 1; }
            if (pageSize == null) { pageSize = 2; }
            return View(dichVus.ToPagedList((int)page, (int)pageSize));
        }
        public ActionResult Introduce()
        {
            return View();
        }
        public ActionResult DoiTuongKD(int? page, int? pageSize)
        {
            if (page == null) { page = 1; }
            if (pageSize == null) {  pageSize = 12; }
            doiTuongKDs = doiTuongKDs.Where(n=>n.MaPLDTKD != "DV").ToList();
            return View(doiTuongKDs.ToPagedList((int)page,(int)pageSize));
        }
        public async Task<ActionResult> ChiTietDoDung(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoDungTC doDungTC =  dbContext.DoDungTCs.Find(id);
            if (doDungTC == null)
            {
                return HttpNotFound();
            }
            return View(doDungTC);
        }

        public async Task<ActionResult> ChiTietThuCung(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThuCung thuCung = dbContext.ThuCungs.Find(id);
            if (thuCung == null)
            {
                return HttpNotFound();
            }
            return View(thuCung);
        }

        public async Task<ActionResult> ChiTietDichVu(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DichVu dichVu = dbContext.DichVus.Find(id);
            if (dichVu == null)
            {
                return HttpNotFound();
            }
            return View(dichVu);
        }
    }
}