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
        public SearchController()
        {
            var bci = new BreadCrumItem("Search", "Index", "Search");
            ListeBreadCrumItem.Add(bci);
        }

        // GET: Search
        public ActionResult Index()
        {
            var db = new BestArtEntities();
            SearchViewModel svm = new SearchViewModel();
            //svm.CatSousCat = db.SousCategorie.OrderBy(c => c.Nom)
            //    .ToDictionary(c => c.Nom,
            //    r => r.Categories.OrderBy(d => d.Nom)
            //        .ToDictionary(d => d.NumDep, d => d.Nom)
            //        );
            var liste = db.Categories.OrderBy(x => x.Libelle).ToList();            
            foreach(var item in liste)
            {
                svm.ListeCategorie.Add(new SelectListItem() { Text = item.Libelle, Value = item.IdCategorie.ToString() }); 
            } 
            ViewBag.PrixMaxSlider = Math.Ceiling((float)db.Produits.Max(x => x.Prix) / 1000) * 1000;

            return View(svm);
        }
    }
}