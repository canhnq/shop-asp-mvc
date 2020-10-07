using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shop_asp_mvc.Models
{
    public class ItemGioHang
    {
        [DisplayName("Mã sản phẩm")]
        public int MaSP { get; set; }
        [DisplayName("Tên sản phẩm")]
        public string TenSP { get; set; }
        [DisplayName("Số lượng")]
        [Required(ErrorMessage = "Hãy nhập vào {0}")]
        [Range(0,10,ErrorMessage = "{0} từ {1} đến {2}")]
        public int SoLuong { get; set; }
        [DisplayName("Đơn giá")]
        public decimal DonGia { get; set; }
        [DisplayName("Thành viên")]
        public decimal ThanhTien { get; set; }
        [DisplayName("Hình ảnh")]
        public string HinhAnh { get; set; }
        public ItemGioHang()
        {
            
        }

        public ItemGioHang(int iMaSP)
        {
            using (QLBanHangEntities db = new QLBanHangEntities())
            {
                this.MaSP = iMaSP;
                SanPham sp = db.SanPhams.Single(n => n.MaSP == iMaSP);
                this.TenSP = sp.TenSP;
                this.HinhAnh = sp.HinhAnh;
                this.DonGia = sp.DonGia.Value;
                this.SoLuong = 1;
                this.ThanhTien = DonGia * SoLuong;
            }
        }

        public ItemGioHang(int iMaSP,int sl)
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