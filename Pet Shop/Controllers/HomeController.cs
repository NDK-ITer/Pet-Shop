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
        List<DoiTuongKD> doiTuongKDs;
        List<DichVu> dichVus = dbContext.DichVus.ToList();
        List<ThuCung> thuCungs = dbContext.ThuCungs.ToList();

        public HomeController() 
        {
            doiTuongKDs = dbContext.DoiTuongKDs.Where(n => n.MaPLDTKD != "DV").ToList();
            //Session.Add("DTKD",doiTuongKDs);
        }

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
        public ActionResult ThuCung(int? page, int? pageSize)
        {
            if (page == null) { page = 1; }
            if (pageSize == null) { pageSize = 2; }
            return View(thuCungs.ToPagedList((int)page, (int)pageSize));
        }
        public ActionResult Introduce()
        {
            return View();
        }
        public ActionResult DoiTuongKD(int? page, int? pageSize)
        {
            if (page == null) { page = 1; }
            if (pageSize == null) { pageSize = 12; }
            return View(doiTuongKDs.ToPagedList((int)page,(int)pageSize));
        }
        [HttpGet]
        public ActionResult DoiTuongKD(int? page, int? pageSize, string searchKey)
        {
            if (page == null) { page = 1; }
            if (pageSize == null) { pageSize = 12; }
            if (string.IsNullOrEmpty(searchKey))
            {
                return View(doiTuongKDs.ToPagedList((int)page, (int)pageSize));
            }
            List<DoiTuongKD> doDung = new List<DoiTuongKD>();
            List<DoiTuongKD> thuCung = new List<DoiTuongKD>();
            List<DoiTuongKD> listSearch = new List<DoiTuongKD>();
            if (!string.IsNullOrEmpty(searchKey))
            {
                searchKey = searchKey.ToLower();
                foreach (var item in doiTuongKDs)
                {
                    if (item.MaPLDTKD == "DD")
                    {
                        if ((item.DoDungTC.TenDD.ToLower().Contains(searchKey)/*|| item.DoDungTC.LoaiThuCung.TenLoai.ToLower().Contains(searchKey)*//*|| item.DoDungTC.LoaiDD.TenLoaiDD.ToLower().Contains(searchKey)*/))
                        {
                            doDung.Add(item);
                            continue;
                        }
                    }
                    if (item.MaPLDTKD == "TC")
                    {
                        if ((item.ThuCung.TenTC.ToLower().Contains(searchKey)/*|| item.ThuCung.LoaiThuCung.TenLoai.ToLower().Contains(searchKey)*/))
                        {
                            thuCung.Add(item);
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                listSearch.AddRange(doDung);
                listSearch.AddRange(thuCung);
            }
            return View(listSearch.ToPagedList((int)page, (int)pageSize));
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