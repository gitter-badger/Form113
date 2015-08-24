using Form113.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form113.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            var db = new BestArtEntities();
            SearchViewModel svm = new SearchViewModel();
            svm.CatSousCat = db.SousCategories.OrderBy(c => c.Nom)
                .ToDictionary(c => c.Nom,
                r => r.Categories.OrderBy(d => d.Nom)
                    .ToDictionary(d => d.NumDep, d => d.Nom)
                    );
            return View(svm);
        }
    }
}