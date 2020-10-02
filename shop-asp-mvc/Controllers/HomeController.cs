using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shop_asp_mvc.Models;
using CaptchaMvc.HtmlHelpers;
using CaptchaMvc;

namespace shop_asp_mvc.Controllers
{
    public class HomeController : Controller
    {
        QLBanHangEntities db = new QLBanHangEntities();
        // GET: Home
        public ActionResult Index()
        {
            var lstDTM = db.SanPhams.Where(n => n.MaLoaiSP == 1 && n.Moi == 1 && n.DaXoa == false).ToList();
            ViewBag.lstDTM = lstDTM;

            var lstMTBM = db.SanPhams.Where(n => n.MaLoaiSP == 2 && n.Moi == 1 && n.DaXoa == false).ToList();
            ViewBag.lstMTBM = lstMTBM;

            var lstLTM = db.SanPhams.Where(n => n.MaLoaiSP == 3 && n.Moi == 1 && n.DaXoa == false).ToList();
            ViewBag.lstLTM = lstLTM;

            return View();
        }

        public ActionResult MenuPartial()
        {
            var lstSP = db.SanPhams;

            return PartialView(lstSP);
        }

        [HttpGet]
        public ActionResult DangKy()
        {
            ViewBag.CauHoi = new SelectList(LoadCauHoi());
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(ThanhVien tv)
        {
            ViewBag.CauHoi = new SelectList(LoadCauHoi());
            if (this.IsCaptchaValid("Captcha is not valid")){
                if (ModelState.IsValid)
                {
                    ViewBag.ThongBao = "Đăng ký thành công!!!";
                    db.ThanhViens.Add(tv);
                    db.SaveChanges();
                }
                else
                {
                    ViewBag.ThongBao = "Đăng ký thất bại!!!";
                }
                
                return View();
            }

            ViewBag.ThongBao = "Sai mã Captcha!!!";

            return View();
        }

        public List<string> LoadCauHoi()
        {
            List<string> lstCauHoi = new List<string>();
            lstCauHoi.Add("Con vật mà bạn yêu thích?");
            lstCauHoi.Add("Ca sĩ mà bạn yêu thích?");
            lstCauHoi.Add("Nghề nghiệp của bạn là gì?");
            return lstCauHoi;
        }

        //Xây dựng Action đăng nhập
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            //Kiểm tra tên đăng nhập và mật khẩu
            string sTaiKhoan = f["txtTaiKhoan"].ToString();
            string sMatKhau = f["txtMatKhau"].ToString();

            ThanhVien tv = db.ThanhViens.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);

            if (tv != null)
            {
                Session["TaiKhoan"] = tv;
                return Content("<script>window.location.reload();</script>");
            }
            return Content("Tài khoản hoặc mật khẩu không đúng!");
            //string taikhoan = f["txtTaiKhoan"].ToString();
            //string matkhau = f["txtMatKhau"].ToString();

            //ThanhVien tv = db.ThanhViens.SingleOrDefault(n => n.TaiKhoan == taikhoan && n.MatKhau == matkhau);
            //if (tv != null)
            //{
            //    //Láy ra List quyền của thành viên tương ứng với loại thành viên
            //    var lstQuyen = db.LoaiThanhVien_Quyen.Where(n => n.MaLoaiTV == tv.MaLoaiTV);
            //    //Duyệt list quyền
            //    string Quyen = "";
            //    foreach (var item in lstQuyen)
            //    {
            //        Quyen += item.MaQuyen + ",";
            //    }
            //    // Cắt dấu ","
            //    Quyen = Quyen.Substring(0, Quyen.Length - 1);
            //    PhanQuyen(tv.TaiKhoan, Quyen);
            //    Session["TaiKhoan"] = tv;
            //    return Content("<script>window.location.reload()</script>");
            //}
            //return Content("Tài khoản hoặc mật khẩu không đúng!");

        }

        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index");
        }
    }
}