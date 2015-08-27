using DataLayer.Models;
using Form113.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Form113.Infrastructure.SearchArt;
using Form113.Infrastructure.SearchArt.Base;
using Form113.Infrastructure.SearchArt.Option;

namespace Form113.Controllers
{
    public class CatalogueController : BestArtController
    {
        private static BestArtEntities db = new BestArtEntities();
      
        // GET: Catalogue
       
        public ActionResult IndexCategories()
        {
            var cat = db.Categories.Select(c=>c.IdCategorie).ToList();
            var bci = new BreadCrumItem("Index Categories", "", "");
            ListeBreadCrumItem.Add(bci);
            return View(cat);
        }
        public ActionResult IndexSousCategories(string id)
        {
            if (id == null) { return RedirectToAction("IndexCategories"); }
            else {
                var idcat = Int32.Parse(id);
                var cat = db.SousCategories.Where(sc => sc.IdCategorie == idcat).Select(sc => sc.IdSousCategorie).ToList();
                var bci = new BreadCrumItem("Index Categories", "IndexCategories", "Catalogue");
                ListeBreadCrumItem.Add(bci);
                bci = new BreadCrumItem(db.Categories.Where(c => c.IdCategorie == idcat).FirstOrDefault().Libelle, "", "");
                ListeBreadCrumItem.Add(bci);
                ViewBag.idcat = idcat;
                return View(cat);
            }
            
        }
        public ActionResult ProduitsCategorie(string id)
        {
            var svm = SearchViewModel.InitializeSVM();
            List<Produits> result=null;
            if (id !=null)
            {
                var idcat = Int32.Parse(id);

                svm.idCategories = new int[] { idcat };
                var sousCategories = db.SousCategories.Where(sc => sc.IdCategorie == idcat).Select(sc => sc.IdSousCategorie).ToList();
                result = db.Produits.Where(p =>sousCategories.Contains(p.IdSousCategorie)).ToList();
            }
            else
            {
                result = db.Produits.ToList();
                svm.idCategories=null;

            }
            svm.Prixmax = db.Produits.Max(p => p.Prix);

            var rvm = ResultViewModels.RvmCreate(svm, result);
            rvm.BackToSearch = false;

            var bci = new BreadCrumItem("Index Categories", "IndexCategories", "Catalogue");
            ListeBreadCrumItem.Add(bci);
            return View("../Produit/Result", rvm);


        }

        public ActionResult ProduitsSousCategorie(string id)
        {
            var idsouscat = Int32.Parse(id);
            var svm = SearchViewModel.InitializeSVM();
            svm.idCategories=new int[] {(int)db.SousCategories.Where(sc=>sc.IdSousCategorie==idsouscat).FirstOrDefault().IdCategorie};
            svm.idSousCategories = new int[] { idsouscat };
            svm.Prixmax = db.Produits.Max(p => p.Prix);
            var result = db.Produits.Where(p => p.IdSousCategorie == idsouscat).ToList();

            var rvm=ResultViewModels.RvmCreate(svm,result);
            rvm.BackToSearch = false;

            var bci = new BreadCrumItem("Index Categories", "IndexCategories", "Catalogue");
            ListeBreadCrumItem.Add(bci);
            var cat=db.Categories.Where(c=>c.IdCategorie==db.SousCategories.Where(sc=>sc.IdSousCategorie==idsouscat).FirstOrDefault().IdCategorie).FirstOrDefault();
            bci = new BreadCrumItem(cat.Libelle,"IndexSousCategories/"+cat.IdCategorie,"Catalogue");
            ListeBreadCrumItem.Add(bci);
            bci = new BreadCrumItem(db.SousCategories.Where(sc=>sc.IdSousCategorie==idsouscat).FirstOrDefault().Nom, "", "");
            ListeBreadCrumItem.Add(bci);

            return View("../Produit/Result",rvm);
        }

    }//fin classe
}