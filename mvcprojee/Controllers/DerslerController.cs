using mvcprojee.Models;
using mvcprojee.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcprojee.Controllers
{
    public class DerslerController : Controller
    {
        db01Entities db = new db01Entities();
        public ActionResult Index()
        {
            List<Dersler> dersListe = db.Dersler.ToList();
            return View(dersListe);
        }
        public ActionResult yeniKayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yeniKayit(dersModel model)
        {
            Dersler kayit = new Dersler();
            kayit.dersadi = model.dersadi;
            kayit.ogretmen = model.ogretmen;
            kayit.derssaati = model.derssaati;

            db.Dersler.Add(kayit);
            db.SaveChanges();

            ViewBag.sonuc = "Kayıt Yapıldı";
            return View();
        }
        public ActionResult kayitDuzenle(int ? id)
        {
            Dersler kayit = db.Dersler.Where(k => k.dersid == id).SingleOrDefault();
            dersModel model = new dersModel();

            model.dersid = kayit.dersid;
            model.dersadi = kayit.dersadi;
            model.ogretmen = kayit.ogretmen;
            model.derssaati = kayit.derssaati;
          
            return View(model);
        }
        public ActionResult kayitSil(int ? id)
        {
            Dersler kayit = db.Dersler.Where(k => k.dersid == id).SingleOrDefault();
            db.Dersler.Remove(kayit);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult kayitDuzenle(dersModel m)
        {
            Dersler kayit = db.Dersler.Where(k => k.dersid == m.dersid).SingleOrDefault();
            kayit.dersadi = m.dersadi.Trim();
            kayit.ogretmen = m.ogretmen.Trim();
            kayit.derssaati = m.derssaati.Trim();
            db.Entry(kayit).State = System.Data.Entity.EntityState.Modified;
            try
            {
                db.SaveChanges();

            }catch(DbEntityValidationException ex)
            {
                throw new Exception(ex.ToString());
            }
            ViewBag.sonuc = "Kayıt Düzenlendi";
            return View();
        }
    }
}