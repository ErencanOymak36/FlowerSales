using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Entity;

namespace WebApplication1.Controllers
{
    public class BirthDayController : Controller
    {
        // GET: BirthDay
        FlowersEntities2 db = new FlowersEntities2();
        public ActionResult BirthDay()
        {
            var degerler = db.TBL_DG.ToList();
            return View(degerler);
        }
    }
}