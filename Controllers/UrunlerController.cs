using MVC_Stok.Models.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PagedList.Mvc;
using PagedList;

namespace MVC_Stok.Controllers
{
    public class UrunlerController : Controller
    {
       MVC_DB_STOKEntities contex=new MVC_DB_STOKEntities();
        public ActionResult UrunListele(int sayfa=1)
        {
            //var values=contex.TblUrunler.ToList();
            var values = contex.TblUrunler.ToList().ToPagedList(sayfa,5);
            return View(values);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> Degerler= (from i in contex.TblCategory.ToList()
                                           select new SelectListItem
                                           {
                                           Text = i.CategoryAd,
                                           Value = i.CategoryId.ToString()
                                           }).ToList();
            ViewBag.x = Degerler;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle( TblUrunler tblUrunler)
        {
            var Kategori = contex.TblCategory.Where(x => x.CategoryId == tblUrunler.TblCategory.CategoryId).FirstOrDefault();
            tblUrunler.TblCategory= Kategori; 
            contex.TblUrunler.Add(tblUrunler);
            contex.SaveChanges();
            return RedirectToAction("UrunListele");
        }
       
        public ActionResult UrunSil(int id)
        {
            var value = contex.TblUrunler.Find(id);
            contex.TblUrunler.Remove(value);
            contex.SaveChanges();
            return RedirectToAction("UrunListele");
        }
        [HttpGet]
        public ActionResult UrunGüncelle(int id)
        {
            var values = contex.TblUrunler.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UrunGüncelle(TblUrunler tblUrunler)
        {
            var values = contex.TblUrunler.Find(tblUrunler.UrunId);
            values.UrunAd=tblUrunler.UrunAd;
            values.Category=tblUrunler.Category;
            values.Fiyat=tblUrunler.Fiyat;
            values.Marka=tblUrunler.Marka;
            values.Stok=tblUrunler.Stok;
            contex.SaveChanges();
            return RedirectToAction("UrunListele");
        }

    }
}