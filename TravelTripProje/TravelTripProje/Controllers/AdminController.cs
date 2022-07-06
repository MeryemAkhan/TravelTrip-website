using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Sınıflar;

namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]    //sayfa yüklendiği zaman çalışacak..
        public ActionResult YeniBlog()
        {
              return View();
        }
        [HttpPost]     //sayfadaki yaptığım işlemleri döndürecek..
        public ActionResult YeniBlog(Blog p)   //aynı isimde olduğu için p isminde parametre türettim.
        {
            c.Blogs.Add(p);             //oluşturduğum textbox lardan alınan verileri ekleme işlemi..
            c.SaveChanges();            //değişiklikleri kaydetme..
            return RedirectToAction("Index");    //index aksiyonuna yönlendir..
        }
        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);  // id den gelen değeri bul..
            c.Blogs.Remove(b);   //b den gelen değerleri sil..
            c.SaveChanges();  //değisiklikleri kakydet..
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var bl = c.Blogs.Find(id);
            return View("BlogGetir", bl); // bloggetir sayfasını döndür ve bl den gelen değerleri göster..
        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.ID); //b den gonderdiğin id ye göre ilgili blogu bul..
            blg.Baslik = b.Baslik;
            blg.Aciklama = b.Aciklama;
            blg.BlogImage = b.BlogImage;
            blg.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar); // yorumlar listesini getir..
        }
        public ActionResult YorumSil(int id)
        {
            var b = c.Yorumlars.Find(id);  // id den gelen değeri bul..
            c.Yorumlars.Remove(b);   //b den gelen değerleri sil..
            c.SaveChanges();  //değisiklikleri kakydet..
            return RedirectToAction("YorumListesi"); //Yorum listesi sayfasına yönlendirme..
        }
        public ActionResult YorumGetir(int id)
        {
            var yr = c.Yorumlars.Find(id);
            return View("YorumGetir", yr); // bloggetir sayfasını döndür ve bl den gelen değerleri göster..
        }
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = c.Yorumlars.Find(y.ID); //b den gonderdiğin id ye göre ilgili blogu bul..
            yrm.KullaniciAdi = y.KullaniciAdi;
            yrm.Mail = y.Mail;
            yrm.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}