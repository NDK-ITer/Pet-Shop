using Pet_Shop.Models;
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
        List<DoDungTC> doDungTCs = dbContext.DoDungTCs.ToList();
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
        public ActionResult DoDungTC(int? page, int? pageSize)
        {
            if (page == null) { page = 1; }
            if (pageSize == null) {  pageSize = 12; }
            return View(doDungTCs.ToPagedList((int)page,(int)pageSize));
        }
        public async Task<ActionResult> ChiTietSP(string id)
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
    }
}