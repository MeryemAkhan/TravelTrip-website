using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Sınıflar;
namespace TravelTripProje.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        Context c = new Context(); //context sınıfından yeni nesne oluştu..

        public ActionResult Index()
        {
            var degerler = c.Hakkimizdas.ToList(); // hakkımızda tablosuna ulaşıp degerleri listele dedim..
            return View(degerler);
        }
    }
}