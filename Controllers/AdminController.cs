using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Entity;

namespace WebApplication1.Controllers
{
    
   
    public class AdminController : Controller
    {
        FlowersEntities2 db = new FlowersEntities2();
        // GET: Admin

      
        public ActionResult Index()
        {
            
           
            return View();
        }
        public static string GetMD5_2(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;
            for(int i = 0;i<targetData.Length;i++)
            {
                byte2String += targetData[i].ToString("x2");
            }
            return byte2String;

        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection bilgi)
        {
            string kullanıcıad = bilgi["kullanıcıad"].ToString();
            string password = GetMD5_2(bilgi["password"].ToString());
            var count = db.TBL_KULLANICI.Where(x => x.KULLANICIAD == kullanıcıad && x.PASSWORD == password).Count();

            if(count==0)
            {
                ViewData["sonuc"] = "SİSTEME GİRİŞ İZNİNİZ BULUNMAMAKTADIR!!!!";
            }
            else
            {
                Session["session_Login"] = true;
                Session["session_kullanıcıad"] = kullanıcıad;
                ViewData["sonuc"] = "GİRİŞ BAŞARILI YÖNLENDİRİLME İÇİN LÜTFEN BİR KAÇ SANİYE BEKLEYİN.";
                return RedirectToAction("Tablolar", "Admin");
            }
            return View();
        }
        public ActionResult Tablolar()
        {
            var degerler = db.TBL_ANNE.ToList();
            return View(degerler);
        }

        public ActionResult TabloDG()
        {
            var degerler = db.TBL_DG.ToList();
            return View(degerler);
        }

        public ActionResult TabloWED()
        {
            var degerler = db.TBL_WEDDING.ToList();
            return View(degerler);
        }

        public ActionResult TabloJOB()
        {
            var degerler = db.TBL_YENIIS.ToList();
            return View(degerler);
        }

        public ActionResult TabloSEV()
        {
            var degerler = db.TBL_SEVGİLİ.ToList();
            return View(degerler);
        }

        public ActionResult TabloNEWYEAR()
        {
            var degerler = db.TBL_YENIYIL.ToList();
            return View(degerler);
        }


        [HttpGet]
        public ActionResult Ekle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Ekle(TBL_ANNE p1)
        {
            db.TBL_ANNE.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Tablolar");
        }

        [HttpGet]
        public ActionResult Ekledg()
        {
        
            return View();
        }
        [HttpPost]
        public ActionResult Ekledg(TBL_DG p1)
        {
            db.TBL_DG.Add(p1);
            db.SaveChanges();
            return RedirectToAction("TabloDG");
        }


        [HttpGet]
        public ActionResult Eklewed()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Eklewed(TBL_WEDDING p1)
        {
            db.TBL_WEDDING.Add(p1);
            db.SaveChanges();
            return RedirectToAction("TabloWED");
        }

        [HttpGet]
        public ActionResult Eklejob()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Eklejob(TBL_YENIIS p1)
        {
            db.TBL_YENIIS.Add(p1);
            db.SaveChanges();
            return RedirectToAction("TabloJOB");
        }



        [HttpGet]
        public ActionResult Eklesev()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Eklesev(TBL_SEVGİLİ p1)
        {
            db.TBL_SEVGİLİ.Add(p1);
            db.SaveChanges();
            return RedirectToAction("TabloSEV");
        }

        [HttpGet]
        public ActionResult Ekleyear()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Ekleyear(TBL_YENIYIL p1)
        {
            db.TBL_YENIYIL.Add(p1);
            db.SaveChanges();
            return RedirectToAction("TabloNEWYEAR");
        }



        public ActionResult SİL(int id)
        {
            var urun = db.TBL_ANNE.Find(id);
            db.TBL_ANNE.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Tablolar");

        }

        public ActionResult SİLdg(int id)
        {
            var urun = db.TBL_DG.Find(id);
            db.TBL_DG.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("TabloDG");

        }

        public ActionResult SİLwed(int id)
        {
            var urun = db.TBL_WEDDING.Find(id);
            db.TBL_WEDDING.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("TabloWED");

        }

        public ActionResult SİLjob(int id)
        {
            var urun = db.TBL_YENIIS.Find(id);
            db.TBL_YENIIS.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("TabloJOB");


        }

        public ActionResult SİLsev(int id)
        {
            var urun = db.TBL_SEVGİLİ.Find(id);
            db.TBL_SEVGİLİ.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("TabloSEV");

        }

        public ActionResult SİLyear(int id)
        {
            var urun = db.TBL_YENIYIL.Find(id);
            db.TBL_YENIYIL.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("TabloNEWYEAR");

        }

        public ActionResult AnneGetir(int id)
        {
            var urun = db.TBL_ANNE.Find(id);
            return View("AnneGetir", urun);
        }

        public ActionResult AnneGuncelle(TBL_ANNE p1)
        {
            var urun = db.TBL_ANNE.Find(p1.FLOWERID);
            urun.FLOWERNAME = p1.FLOWERNAME;
            urun.FIYAT = p1.FIYAT;
            urun.STOK = p1.STOK;
            urun.PHOTO = p1.PHOTO;
            db.SaveChanges();
            return RedirectToAction("Tablolar");
        }


        public ActionResult DgGetir(int id)
        {
            var urun = db.TBL_DG.Find(id);
            return View("DgGetir", urun);
        }

        public ActionResult DgGuncelle(TBL_DG p1)
        {
            var urun = db.TBL_DG.Find(p1.FLOWERID);
            urun.FLOWERNAME = p1.FLOWERNAME;
            urun.FIYAT = p1.FIYAT;
            urun.STOK = p1.STOK;
            urun.PHOTO = p1.PHOTO;
            db.SaveChanges();
            return RedirectToAction("TabloDG");
        }


        public ActionResult JobGetir(int id)
        {
            var urun = db.TBL_YENIIS.Find(id);
            return View("JobGetir", urun);
        }

        public ActionResult JobGuncelle(TBL_YENIIS p1)
        {
            var urun = db.TBL_YENIIS.Find(p1.FLOWERID);
            urun.FLOWERNAME = p1.FLOWERNAME;
            urun.FIYAT = p1.FIYAT;
            urun.STOK = p1.STOK;
            urun.PHOTO = p1.PHOTO;
            db.SaveChanges();
            return RedirectToAction("TabloJOB");
        }


        public ActionResult YearGetir(int id)
        {
            var urun = db.TBL_YENIYIL.Find(id);
            return View("YearGetir", urun);
        }

        public ActionResult YearGuncelle(TBL_YENIYIL p1)
        {
            var urun = db.TBL_YENIYIL.Find(p1.FLOWERID);
            urun.FLOWERNAME = p1.FLOWERNAME;
            urun.FIYAT = p1.FIYAT;
            urun.STOK = p1.STOK;
            urun.PHOTO = p1.PHOTO;
            db.SaveChanges();
            return RedirectToAction("TabloNEWYEAR");
        }


        public ActionResult SevGetir(int id)
        {
            var urun = db.TBL_SEVGİLİ.Find(id);
            return View("SevGetir", urun);
        }

        public ActionResult SevGuncelle(TBL_SEVGİLİ p1)
        {
            var urun = db.TBL_SEVGİLİ.Find(p1.FLOWERID);
            urun.FLOWERNAME = p1.FLOWERNAME;
            urun.FIYAT = p1.FIYAT;
            urun.STOK = p1.STOK;
            urun.PHOTO = p1.PHOTO;
            db.SaveChanges();
            return RedirectToAction("TabloSEV");
        }


        public ActionResult WedGetir(int id)
        {
            var urun = db.TBL_WEDDING.Find(id);
            return View("WedGetir", urun);
        }

        public ActionResult WedGuncelle(TBL_WEDDING p1)
        {
            var urun = db.TBL_WEDDING.Find(p1.FLOWERID);
            urun.FLOWERNAME = p1.FLOWERNAME;
            urun.FIYAT = p1.FIYAT;
            urun.STOK = p1.STOK;
            urun.PHOTO = p1.PHOTO;
            db.SaveChanges();
            return RedirectToAction("TabloWED");
        }
      
        public ActionResult ClientLogin()
        {
            ViewBag.Result = "Kaydınız başarıyla tamamlanmıştır.";
          
            return View();
        }

        public ActionResult SalerLogin()
        {
            ViewBag.Result2 = "Kayıt formunuz gönderilmiştir en kısa sürede dönüş yapılacaktır.";
            
            return View();
        }

    }

}