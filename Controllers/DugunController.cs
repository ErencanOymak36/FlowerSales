using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Entity;

namespace WebApplication1.Controllers
{
    public class DugunController : Controller
    {
        // GET: Dugun
        FlowersEntities2 db = new FlowersEntities2();
        public ActionResult Dugun()
        {
            var degerler = db.TBL_WEDDING.ToList();
            return View(degerler);
        }
    }
}