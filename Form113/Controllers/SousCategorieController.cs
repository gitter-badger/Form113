using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form113.Controllers
{
    public class SousCategorieController : Controller
    {
        // GET: SousCategorie
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult SousCategorie(string id)
        {
            var db = new BestArtEntities();
            var idcat = Int32.Parse(id);
            var cat = db.SousCategories.Where(c => c.IdCategorie == idcat).First();
            return PartialView("_SousCategorie", cat);
        }
    }
}