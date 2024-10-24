using MVC_Stok.Models.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace MVC_Stok.Controllers
{
    public class CategoryController : Controller
    {
        MVC_DB_STOKEntities context=new MVC_DB_STOKEntities();
        public ActionResult CategoryList(int sayfa = 1)
        {
            var values = context.TblCategory.ToList().ToPagedList(sayfa, 5);
            return View(values);
        }
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(TblCategory tblCategory)
        {
            context.TblCategory.Add(tblCategory);
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        public ActionResult DeleteCategory(int id)
        {
           var value= context.TblCategory.Find(id);
            context.TblCategory.Remove(value);
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var values = context.TblCategory.Find(id);
            return View(values);
        }
       
        [HttpPost]
        public ActionResult UpdateCategory(TblCategory tblCategory)
        {
            var value = context.TblCategory.Find(tblCategory.CategoryId);
            value.CategoryAd = tblCategory.CategoryAd;
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }


    }
}