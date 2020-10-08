using shop_asp_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace shop_asp_mvc.Controllers
{
    public class SanPhamController : Controller
    {
        QLBanHangEntities db = new QLBanHangEntities();
        // GET: SanPham
        [ChildActionOnly]
        public ActionResult SanPhamStyle1Partial()
        {
            return PartialView();
        }

        public ActionResult XemChiTiet(int? id,string tensp)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == id && n.DaXoa == false);
            if(sp == null)
            {
                return HttpNotFound();
            }
            
            return View(sp);
        } 

        public ActionResult SanPham(int? MaLoaiSP,int? MaNSX,int? page)
        {
            //if(Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            //{
            //    return RedirectToAction("Index");
            //}

            if (MaLoaiSP == null || MaNSX == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var lstSP = db.SanPhams.Where(n => n.MaLoaiSP == MaLoaiSP && n.MaNSX == MaNSX && n.DaXoa == false);
            if (lstSP.Count() == 0)
            {
                return HttpNotFound();
            }
            if(Request.HttpMethod != "GET")
            {
                page = 1;
            }
            int pageSize = 6;
            int pageNumber = (page ?? 1);

            ViewBag.MaLoaiSP = MaLoaiSP;
            ViewBag.MaNSX = MaNSX;

            return View(lstSP.OrderBy(n=>n.MaSP).ToPagedList(pageNumber,pageSize));
        }
    }
}