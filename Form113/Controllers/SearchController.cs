using Form113.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.Models;
namespace Form113.Controllers
{
    public class SearchController : BestArtController
    {
        private static BestArtEntities db = new BestArtEntities();

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
    }
}