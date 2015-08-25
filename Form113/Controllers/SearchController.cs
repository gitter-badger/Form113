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
            var bci = new BreadCrumItem("Search", "Index", "Search");
            ListeBreadCrumItem.Add(bci);
        }

        private SearchViewModel InitializeSVM()
        {
            SearchViewModel svm = new SearchViewModel();

            svm.ListeCategorie = new List<SelectListItem>();
            var liste = db.Categories.OrderBy(x => x.Libelle).ToList();
            foreach (var item in liste)
            {
                svm.ListeCategorie.Add(new SelectListItem() { Text = item.Libelle, Value = item.IdCategorie.ToString() });
            }

            svm.ListeContinents = new List<SelectListItem>();
            var listeCont = db.Continents.OrderBy(x => x.name).ToList();
            foreach (var cont in listeCont)
            {
                svm.ListeContinents.Add(new SelectListItem() { Text = cont.name, Value = cont.idContinent.ToString() });
            }
            return svm;
        }

        public ActionResult Index()
        {
            var svm = InitializeSVM();
            //ViewBag.PrixMaxSlider = Math.Ceiling((float)db.Produits.Max(x => x.Prix) / 1000) * 1000;

            return View(svm);
        }
        [HttpPost]
        public ActionResult Result()
        {
            var svm = InitializeSVM();
            //ViewBag.PrixMaxSlider = Math.Ceiling((float)db.Produits.Max(x => x.Prix) / 1000) * 1000;

            SearchBase search = new Search();

            search = new SearchOptionPays(search, svm.idPays);
            search = new SearchOptionRegion(search, svm.idRegions);
            search = new SearchOptionContinent(search, svm.idContinent);



            svm.ListeProduit = search.GetResult().ToList();



            return View(svm);
        }
    }
}