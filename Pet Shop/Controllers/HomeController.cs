﻿using Pet_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Pet_Shop.Controllers
{
    public class HomeController : Controller
    {
        private static QuanLyThuCungEntities dbContext = new QuanLyThuCungEntities();
        List<DoDungTC> doDungTCs = dbContext.DoDungTCs.ToList();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Service()
        {
            return View();
        }
        public ActionResult Introduce()
        {
            return View();
        }
        public ActionResult DoDungTC(int? page, int? pageSize)
        {
            if (page == null) { page = 1; }
            if (pageSize == null) {  pageSize = 3; }
            return View(doDungTCs.ToPagedList((int)page,(int)pageSize));
        }

        public ActionResult DetailProduct()
        {
            return View();
        }
    }
}