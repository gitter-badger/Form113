using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form113.Controllers
{
    public class ProduitController : BestArtController
    {
        // GET: Produits
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult NbProduits()
        {
            var db = new BestArtEntities();

            var nbproduits = db.Produits.Count();

            return PartialView("_NbProduits", nbproduits);
        }
        
        [ChildActionOnly]
        public PartialViewResult HighlightedProduct()
        {
            var db = new BestArtEntities();

            var nbproduits = db.Produits.Where(p=>(p.Promotion!=0).O;

            return PartialView("_NbProduits", nbproduits);
        }
        HighlightedProduct
    }
}