using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shop_asp_mvc.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        [ChildActionOnly]
        public ActionResult SanPhamStyle1Partial()
        {
            return PartialView();
        }
    }
}