using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shop_asp_mvc.Models;
using PagedList;

namespace shop_asp_mvc.Controllers
{
    public class TimKiemController : Controller
    {
        QLBanHangEntities db = new QLBanHangEntities();
        [HttpGet]
        public ActionResult KQTimKiem(string sTuKhoa, int? page)
        {
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }
            int pageSize = 6;
            int pageNumber = (page ?? 1);

            var lstSP = db.SanPhams.Where(n => n.TenSP.Contains(sTuKhoa));
            ViewBag.TuKhoa = sTuKhoa;
            return View(lstSP.OrderBy(n => n.TenSP).ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult LayTuKhoaTimKiem(string sTuKhoa)
        {
            
            return RedirectToAction("KQTimKiem",new { @sTuKhoa = sTuKhoa });
        }
    }
}