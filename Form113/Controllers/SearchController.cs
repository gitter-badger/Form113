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
            ViewBag.PrixMaxSlider = Math.Ceiling((float)db.Produits.Max(x => x.Prix) / 1000) * 1000;

            return View(svm);
        }
        [HttpPost]
        public ActionResult Result(SearchViewModel svm)
        {
            var bci = new BreadCrumItem("Result", "Result", "");
            ListeBreadCrumItem.Add(bci);
            //ViewBag.PrixMaxSlider = Math.Ceiling((float)db.Produits.Max(x => x.Prix) / 1000) * 1000;



            var result = GetSearchResult(svm);
            var pageSize = 20;
            var itemQty = result.Count();
            var temp = itemQty % pageSize;
            var pageQty = temp == 0 ? itemQty / pageSize : itemQty / pageSize + 1;

            var rvm = new ResultViewModels()
            {
                CurrentPage = 1,
                Result = result.Take(pageSize).ToList(),
                PageSize = pageSize,
                ItemsQty = itemQty,
                PageQty = pageQty,

                XmlSearchviewModel = svm.SerializeSearchViewModel(),

            };




            return View(rvm);
        }


        [HttpPost, ValidateInput(false)]
        public ViewResult Pagination(ResultViewModels rvm)
        {
            var bci = new BreadCrumItem("Result", "Result", "");
            ListeBreadCrumItem.Add(bci);

            var svm = SearchViewModel.UnserializeSearchViewModel(rvm.XmlSearchviewModel);

            var result = GetSearchResult(svm);
            var pageSize = 20;
            var itemQty = result.Count();
            var temp = itemQty % pageSize;
            var pageQty = temp == 0 ? itemQty / pageSize : itemQty / pageSize + 1;

            rvm.Result = result.Skip(pageSize * (rvm.CurrentPage - 1)).Take(pageSize).ToList();
            rvm.CurrentPage = rvm.CurrentPage;
            rvm.PageSize = pageSize;
            rvm.ItemsQty = itemQty;
            rvm.PageQty = pageQty;

            rvm.XmlSearchviewModel = svm.SerializeSearchViewModel();


            return View("Result", rvm);
        }

        private List<Produits> GetSearchResult(SearchViewModel svm)
        {

            SearchBase search = new Search();
            search = new SearchOptionPrixMin(search, svm.Prixmin);
            var res = search.GetResult().ToList();
            search = new SearchOptionPrixMax(search, svm.Prixmax);
             res = search.GetResult().ToList();
            search = new SearchOptionPays(search, svm.idPays);
             res = search.GetResult().ToList();
            search = new SearchOptionRegion(search, svm.idRegions);
             res = search.GetResult().ToList();
            search = new SearchOptionContinent(search, svm.idContinent);
             res = search.GetResult().ToList();
            svm.ListeProduit = res.ToList();

            return svm.ListeProduit;
        }
    }
}