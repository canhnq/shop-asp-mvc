﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shop_asp_mvc.Models
{
    public class GioHang
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
        public string HinhAnh { get; set; }
        public GioHang()
        {
            
        }
        public GioHang(int iMaSP,int sl)
        {
            using (QLBanHangEntities db = new QLBanHangEntities())
            {
                this.MaSP = iMaSP;
                SanPham sp = db.SanPhams.Single(n => n.MaSP == iMaSP);
                this.TenSP = sp.TenSP;
                this.HinhAnh = sp.HinhAnh;
                this.DonGia = sp.DonGia.Value;
                this.SoLuong = sl;
                this.ThanhTien = DonGia * SoLuong;
            }
        }
    }
}