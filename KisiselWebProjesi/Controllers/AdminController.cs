using KisiselWebProjesi.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KisiselWebProjesi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        Context  c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var deger = c.AnaSayfas.ToList();
            return View(deger);
        }

        public ActionResult AnaSayfaGetir(int id)
        {
            var ag = c.AnaSayfas.Find(id);
            return View("AnaSayfaGetir",ag);
        }

        public ActionResult AnaSayfaGüncelle(AnaSayfa x)
        {
            var ag = c.AnaSayfas.Find(x.id);
            ag.isim = x.isim;
            ag.profil = x.profil;
            ag.unvan = x.unvan;
            ag.aciklama = x.aciklama;
            ag.iletisim = x.iletisim;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult İkonListesi()
        {
            var deger = c.İkonlars.ToList();
            return View(deger);
        }

        public ActionResult YeniIkon()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniIkon(ikonlar p)
        {
            c.İkonlars.Add(p);
            c.SaveChanges();
            return RedirectToAction("İkonListesi");
        }

        public ActionResult İkonGetir(int id)
        {
            var ig = c.İkonlars.Find(id);
            return View("İkonGetir",ig);
        }

        public ActionResult İkonGuncelle(ikonlar x)
        {
            var ig = c.İkonlars.Find(x.id);
            ig.ikon = x.ikon;
            ig.link = x.link;
            c.SaveChanges();
            return RedirectToAction("İkonListesi");
        }

        public ActionResult İkonSil(int id)
        {
            var sl = c.İkonlars.Find(id);
            c.İkonlars.Remove(sl);
            c.SaveChanges();
            return RedirectToAction("İkonListesi");
        }
    }
}