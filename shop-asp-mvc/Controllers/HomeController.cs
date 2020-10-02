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
                ViewBag.ThongBao = "Đăng ký thành công!!!";
                db.ThanhViens.Add(tv);
                db.SaveChanges();
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

    }
}