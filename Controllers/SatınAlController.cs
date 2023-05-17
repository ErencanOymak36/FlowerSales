using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Entity;

namespace WebApplication1.Controllers
{
    public class SatınAlController : Controller
    {
        // GET: SatınAl
        FlowersEntities2 db = new FlowersEntities2();


        [HttpGet]
        public ActionResult SatınAl()
        {
            return View();
        }




        [HttpPost]
        public ActionResult SatınAl(TBL_MUSTERI p1)
        {
            db.TBL_MUSTERI.Add(p1);
            db.SaveChanges();
            
            return View();
        }
    }
}