using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shop_asp_mvc.Controllers
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        public ActionResult KQTimKiem(string sTuKhoa)
        {
            return View();
        }
    }
}