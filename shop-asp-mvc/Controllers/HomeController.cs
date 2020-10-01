using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shop_asp_mvc.Models;

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
    }
}