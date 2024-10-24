using MVC_Stok.Models.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using Newtonsoft.Json.Linq;

namespace MVC_Stok.Controllers
{
    public class MusteriController : Controller
    {
        MVC_DB_STOKEntities context=new MVC_DB_STOKEntities();
        public ActionResult MusteriList(int sayfa = 1)
        {
            var values = context.TblMusteri.ToList().ToPagedList(sayfa, 5);
            return View(values);
        }
        
        public ActionResult MusteriList(string p)
        {
            var value=from x in context.TblMusteri select x;
            if (!string.IsNullOrEmpty(p))
            {
                value = value.Where(m => m.MusteriAd.Contains(p));
            }
            return View(value.ToList());
        }
        public ActionResult CreateMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateMusteri(TblMusteri tblMusteri)
        {
            context.TblMusteri.Add(tblMusteri);
            context.SaveChanges();
            return RedirectToAction("MusteriList");
        }
        public ActionResult DeleteMusteri(int id)
        {
            var value=context.TblMusteri.Find(id);
            context.TblMusteri.Remove(value);
            context.SaveChanges();
            return RedirectToAction("MusteriList");
        }
        [HttpGet]
        public ActionResult UpdateMusteri(int id)
        {
            var value = context.TblMusteri.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateMusteri(TblMusteri tblMusteri)
        {
            var values = context.TblMusteri.Find(tblMusteri.MusteriId);
            values.MusteriAd=tblMusteri.MusteriAd;
            values.MusteriSoyad = tblMusteri.MusteriSoyad;
            context.SaveChanges();
            return RedirectToAction("MusteriList");
        }
    }
}