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
using PagedList.Mvc;
using PagedList;

namespace Pet_Shop.Areas.Admin.Controllers
{
    public class DoiTuongKDsManagerController : Controller
    {
        private QuanLyThuCungEntities db = new QuanLyThuCungEntities();

        // GET: Admin/DoiTuongKDs
        public async Task<ActionResult> Index(int? page, int? pageSize)
        {
            if (page == null) { page = 1; }
            if (pageSize == null) {  pageSize = 5; }
            var doiTuongKDs = db.DoiTuongKDs.ToList();
            return View(doiTuongKDs.ToPagedList((int)page,(int)pageSize));
        }
    }
}
