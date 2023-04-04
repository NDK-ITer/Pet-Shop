using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Pet_Shop.Models
{
    public class SPGioHang
    {
        private QuanLyThuCungEntities db = new QuanLyThuCungEntities();
        GioHang gioHang = new GioHang();
        public string MaDD { get; set; }
        public string TenDD { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public string AnhDaiDien { get; set; }
        public double ThanhTien { get { return DonGia * SoLuong; } }

        public SPGioHang(string maDD)
        {
            MaDD = maDD;
            DoDungTC doDungTC = (DoDungTC)db.DoDungTCs.FirstOrDefault(n => n.MaDD == maDD);
            TenDD = doDungTC.TenDD;
            AnhDaiDien = doDungTC.DoiTuongKD.AnhDaiDien;
            DonGia = (double)doDungTC.DoiTuongKD.DonGia;
            SoLuong = 1;
        }

        public void ThemSP(string id)
        {

        }
    }
}