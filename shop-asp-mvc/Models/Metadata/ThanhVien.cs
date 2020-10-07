using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shop_asp_mvc.Models
{
    [MetadataTypeAttribute(typeof(ThanhVienMetadata))]
    public partial class ThanhVien
    {
        internal sealed class ThanhVienMetadata
        {
            [DisplayName("Mã thành viên")]
            public int MaThanhVien { get; set; }
            [DisplayName("Tài khoản")]
            //[StringLength(10,ErrorMessage ="{0} không quá 10 ký tự")]
            [Required(ErrorMessage = "hãy nhập vào {0}")]
            public string TaiKhoan { get; set; }
            [DisplayName("Mật khẩu")]
            [Required(ErrorMessage = "hãy nhập vào {0}")]
            public string MatKhau { get; set; }
            [DisplayName("Họ tên")]
            public string HoTen { get; set; }
            [DisplayName("Địa chỉ")]
            public string DiaChi { get; set; }
            [DisplayName("Email")]
            [Required(ErrorMessage = "The email address is required")]
            [EmailAddress(ErrorMessage = "Invalid Email Address")]
            public string Email { get; set; }
            [DisplayName("Số điện thoại")]
            [StringLength(12, ErrorMessage = "{0} không quá 12 ký tự")]
            [Range(10, 12, ErrorMessage = "{0} phải từ {1} đến {2}")]
            [Required(ErrorMessage = "hãy nhập vào {0}")]
            public string SoDienThoai { get; set; }
            [DisplayName("Câu hỏi")]
            public string CauHoi { get; set; }
            [DisplayName("Câu trả lời")]
            [Required(ErrorMessage = "hãy nhập vào {0}")]
            public string CauTraLoi { get; set; }
            [DisplayName("Mã loại thành viên")]
            public Nullable<int> MaLoaiTV { get; set; }
        }
    }
}