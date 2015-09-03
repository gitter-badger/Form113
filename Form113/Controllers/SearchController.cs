using Form113.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.Models;
using Form113.Infrastructure.SearchArt.Base;
using Form113.Infrastructure.SearchArt.Option;
using Form113.Infrastructure.SearchArt;
namespace Form113.Controllers
{
    public class SearchController : BestArtController
    {
        private static BestArtEntities db = new BestArtEntities();

        public JsonResult GetJSONSCAT(string id)
        {
            int idtempo = int.Parse(id);
            var LD = db.SousCategories.Where(c => c.IdCategorie == idtempo)
                                    .OrderBy(c => c.Nom)
                                    .Select(c => new { nc = c.IdSousCategorie, scat = c.Nom })
                                    .ToList();
            return Json(LD, JsonRequestBehavior.AllowGet);
        }

        public SearchController()
        {
            var bci = new BreadCrumItem("Search", "", "");
            ListeBreadCrumItem.Add(bci);
        }

        public ActionResult Index()
        {
            var svm = SearchViewModel.InitializeSVM();
            ViewBag.PrixMaxSlider = Math.Ceiling((float)db.Produits.Max(x => x.Prix) / 1000) * 1000;

            return View(svm);
        }
    }
}