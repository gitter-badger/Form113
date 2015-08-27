using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form113.Controllers
{
    public class CategorieController : Controller
    {
        // GET: Categorie
        public ActionResult Index()
        {
            return View();
        }

        
        [ChildActionOnly]
        public PartialViewResult Categorie(string id)
        {
            var db=new BestArtEntities();
            var idcat = Int32.Parse(id);
            var cat=db.Categories.Where(c=>c.IdCategorie==idcat).FirstOrDefault();
            return PartialView("_Categorie", cat);
        }
    }
}