using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index(string p)
        {
            var kitaplar = from k in db.TblKitap select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(x => x.KitapAd.Contains(p));
            }
            //var kitaplar = db.TblKitap.ToList();
            return View(kitaplar.ToList());
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> kategorilist = (from i in db.TblKategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KategoriAD,
                                               Value = i.KategoriID.ToString()
                                           }).ToList();
            ViewBag.ktgrList = kategorilist;

            List<SelectListItem> Yazarlist = (from i in db.TblYazar.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.YazarAd+ ' ' +i.YazarSoyad,
                                                  Value = i.YazarID.ToString()
                                              }).ToList();
            ViewBag.yzrList = Yazarlist;
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(TblKitap p)
        {
            var ktg = db.TblKategori.Where(k => k.KategoriID == p.TblKategori.KategoriID).FirstOrDefault();
            var yzr = db.TblYazar.Where(y => y.YazarID == p.TblYazar.YazarID).FirstOrDefault();
            p.TblKategori = ktg;
            p.TblYazar = yzr;
            db.TblKitap.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapSil(int id)
        {
            var kitap = db.TblKitap.Find(id);
            db.TblKitap.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapGetir(int id)
        {
            var kitap = db.TblKitap.Find(id);
            List<SelectListItem> kategorilist = (from i in db.TblKategori.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = i.KategoriAD,
                                                     Value = i.KategoriID.ToString()
                                                 }).ToList();
            ViewBag.ktgrList = kategorilist;

            List<SelectListItem> Yazarlist = (from i in db.TblYazar.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.YazarAd + ' ' + i.YazarSoyad,
                                                  Value = i.YazarID.ToString()
                                              }).ToList();
            ViewBag.yzrList = Yazarlist;
            return View("KitapGetir", kitap);
        }
        public ActionResult KitapGuncelle(TblKitap p)
        {
            var kitap = db.TblKitap.Find(p.KitapID);
            kitap.KitapAd = p.KitapAd;
            kitap.BasımYıl = p.BasımYıl;
            kitap.Sayfa = p.Sayfa;
            kitap.YayınEvi = p.YayınEvi;
            var ktg = db.TblKategori.Where(k => k.KategoriID == p.TblKategori.KategoriID).FirstOrDefault();
            var yzr = db.TblYazar.Where(k => k.YazarID == p.TblYazar.YazarID).FirstOrDefault();
            kitap.Kategori = ktg.KategoriID;
            kitap.Yazar = yzr.YazarID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}