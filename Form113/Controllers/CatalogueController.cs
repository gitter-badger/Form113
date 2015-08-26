using DataLayer.Models;
using Form113.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form113.Controllers
{
    public class CatalogueController : BestArtController
    {
        public CatalogueController()
        {
            var bci = new BreadCrumItem("Index Categories", "Index", "Catalogue");
            ListeBreadCrumItem.Add(bci);
        }
        // GET: Catalogue
       
        public ActionResult IndexCategories()
        {
            var db = new BestArtEntities();
            var cat = db.Categories.Select(c=>c.IdCategorie).ToList();
            return View(cat);
        }
        public ActionResult IndexSousCategories(string id)
        {
            var db = new BestArtEntities();
            var idcat = Int32.Parse(id);
            var cat = db.SousCategories.Where(sc => sc.IdCategorie==idcat).Select(sc=>sc.IdSousCategorie).ToList();
            return View(cat);
        }
    }
}