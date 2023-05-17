using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Entity;

namespace WebApplication1.Controllers
{
    public class AnneController : Controller
    {
        // GET: Anne
        FlowersEntities2 db = new FlowersEntities2();
        public ActionResult Anne()
        {
            var degerler = db.TBL_ANNE.ToList();
            return View(degerler);
        }
       
    }
}