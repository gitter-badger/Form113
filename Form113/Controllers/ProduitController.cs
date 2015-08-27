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
        BestArtEntities db = new BestArtEntities();

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
    }
}