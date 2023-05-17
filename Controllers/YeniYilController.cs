using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Entity;

namespace WebApplication1.Controllers
{
    public class YeniYilController : Controller
    {
        // GET: YeniYil
        FlowersEntities2 db = new FlowersEntities2();
        public ActionResult YeniYil()
        {
            var degerler = db.TBL_YENIYIL.ToList();
            return View(degerler);
        }
    }
}