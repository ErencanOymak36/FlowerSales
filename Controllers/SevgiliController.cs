using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Entity;

namespace WebApplication1.Controllers
{
    public class SevgiliController : Controller
    {
        // GET: Sevgili
        FlowersEntities2 db = new FlowersEntities2();
        public ActionResult Sevgili()
        {
            var degerler = db.TBL_SEVGİLİ.ToList();
            return View(degerler);
        }
    }
}