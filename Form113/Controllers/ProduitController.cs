using DataLayer.Models;
using Form113.Infrastructure.SearchArt;
using Form113.Infrastructure.SearchArt.Base;
using Form113.Infrastructure.SearchArt.Option;
using Form113.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form113.Controllers
{
    public class ProduitController : BestArtController
    {
        BestArtEntities db = new BestArtEntities();

        public ProduitController()
        {
            var bci = new BreadCrumItem("Search", "Index", "Search");
            ListeBreadCrumItem.Add(bci);
        }

        // GET: Produits
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult NbProduits()
        {
            var nbproduits = db.Produits.Count();
            return PartialView("_NbProduits", nbproduits);
        }
        
        [ChildActionOnly]
        public PartialViewResult HighlightedProduct()
        {
            var res = db.Produits.OrderBy(p=>(p.DateMiseEnVente)).Take(3).Select(p=>p.IdProduit).ToList();
            return PartialView("_HighlightedProduct", res);
        }

        [ChildActionOnly]
        public PartialViewResult MiniatProduit(string id)
        {
            var idprod = Int32.Parse(id);
            var res = db.Produits.Where(p => p.IdProduit == idprod).First();
            return PartialView("_MiniatProduit",res);
        }

        public PartialViewResult AfficheProduit(string id)
        {
            var idprod = Int32.Parse(id);
            var res = db.Produits.Where(p => p.IdProduit == idprod).First();
            return PartialView("_Produit", res);
        }

        [HttpPost]
        public ActionResult Result(SearchViewModel svm)
        {
            var bci = new BreadCrumItem("Result", "Result", "");
            ListeBreadCrumItem.Add(bci);
            //ViewBag.PrixMaxSlider = Math.Ceiling((float)db.Produits.Max(x => x.Prix) / 1000) * 1000;

            var result = GetSearchResult(svm);
            var pageSize = 30;
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
                BackToSearch=true,

                XmlSearchviewModel = svm.SerializeSearchViewModel(),

            };
            return View(rvm);
        }

        [HttpPost, ValidateInput(false)]
        public ViewResult RetourRecherche(ResultViewModels rvm)
        {
            var bci = new BreadCrumItem("Index", "Index", "");
            ListeBreadCrumItem.Add(bci);

            var svm = SearchViewModel.InitializeSVM();
            var svmres = SearchViewModel.UnserializeSearchViewModel(rvm.XmlSearchviewModel);
            svmres.ListeCategorie = svm.ListeCategorie;
            svmres.ListeContinents = svm.ListeContinents;


            string srcSC = "";
            int i = 0;
            if (svmres.idSousCategories != null)
                foreach (var item in svmres.idSousCategories)
                {
                    if (i != 0)
                    {
                        srcSC += "/";
                    }
                    srcSC += item.ToString();
                    i++;
                }
            string srcP = "";
            i = 0;
            if (svmres.idPays != null)
                foreach (var item in svmres.idPays)
                {
                    if (i != 0)
                    {
                        srcP += "/";
                    }
                    srcP += item.ToString();
                    i++;
                }


            ViewBag.PrixMaxSlider = Math.Ceiling((float)db.Produits.Max(x => x.Prix) / 1000) * 1000;

            ViewBag.listeSC = srcSC;
            if (svmres.idRegions != null)
                ViewBag.listeR = svmres.idRegions[0].ToString();
            ViewBag.listeP = srcP;

            return View("../Search/Index",svmres);
        }

        public ActionResult Detail(int id)
        {
            var V = db.Produits.Where(p => p.IdProduit == id).FirstOrDefault();
            V.NbVues++;
            db.SaveChanges();
            return View(V);
        }

        public ActionResult Compare(ResultViewModels CVM)
        {
            return View(CVM);
        }

        public PartialViewResult CompareProduits(int id)
        {
            var P = db.Produits.Where(p => p.IdProduit == id).FirstOrDefault();
            return PartialView("_CompareProduits", P);
        }

        [HttpPost, ValidateInput(false)]
        public ViewResult Pagination(ResultViewModels rvm)
        {
            
            var bci = new BreadCrumItem("Result", "Result", "");
            ListeBreadCrumItem.Add(bci);

            var svm = SearchViewModel.UnserializeSearchViewModel(rvm.XmlSearchviewModel);

            var result = GetSearchResult(svm);
            var pageSize = 30;
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

         //Boutton admin
        [ChildActionOnly]
        public PartialViewResult AdminPart()
        {
            return PartialView("_AdminProduit");
        }

        private List<Produits> GetSearchResult(SearchViewModel svm)
        {

            SearchBase search = new Search();
            search = new SearchOptionPrixMin(search, svm.Prixmin);
            search = new SearchOptionPrixMax(search, svm.Prixmax);
            search = new SearchOptionPays(search, svm.idPays);
            search = new SearchOptionRegion(search, svm.idRegions);
            search = new SearchOptionContinent(search, svm.idContinent);
            var res = search.GetResult().ToList();
            svm.ListeProduit = res.ToList();

            return svm.ListeProduit;
        }
    }
}