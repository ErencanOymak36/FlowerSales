using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Entity;

namespace WebApplication1.Controllers
{
    public class NewJobController : Controller
    {
        // GET: NewJob
        FlowersEntities2 db = new FlowersEntities2();
        public ActionResult NewJob()
        {
            var degerler = db.TBL_YENIIS.ToList();
            return View(degerler);
        }
    }
}