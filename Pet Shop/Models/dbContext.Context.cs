﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pet_Shop.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QuanLyThuCungEntities : DbContext
    {
        public QuanLyThuCungEntities()
            : base("name=QuanLyThuCungEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CT_HoaDon> CT_HoaDon { get; set; }
        public virtual DbSet<CT_PhieuDat> CT_PhieuDat { get; set; }
        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<DoDungTC> DoDungTCs { get; set; }
        public virtual DbSet<DoiTuongKD> DoiTuongKDs { get; set; }
        public virtual DbSet<HangSX> HangSXes { get; set; }
        public virtual DbSet<HinhAnhDTKD> HinhAnhDTKDs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<LoaiThuCung> LoaiThuCungs { get; set; }
        public virtual DbSet<NhanSU> NhanSUs { get; set; }
        public virtual DbSet<PhieuDat> PhieuDats { get; set; }
        public virtual DbSet<ThuCung> ThuCungs { get; set; }
    }
}
