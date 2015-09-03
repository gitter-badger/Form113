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
       /// <summary>
        /// public ActionResult IndexCategories()
       /// index du catalogue, fournit une liste d'id de catégorie à la vue IndexCategorie qui appellera des vues partielles pour afficher les categories
       /// </summary>
       /// <returns></returns>
        public ActionResult IndexCategories()
        {
            var cat = db.Categories.Select(c=>c.IdCategorie).ToList();
            var bci = new BreadCrumItem("Index Categories", "", "");
            ListeBreadCrumItem.Add(bci);
            return View(cat);
        }

        /// <summary>
        /// public ActionResult IndexSousCategories(string id)
        /// Retourne la liste des id des sous catégories de la catégorie sélectionnée à partir de son id
        /// </summary>
        /// <param name="id">id de la categorie selectyionnée par le visiteur</param>
        /// <returns></returns>
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

        /// <summary>
        /// public ActionResult ProduitsCategorie(string id)
        /// pour gérer les cas d'affichage de "toutes les sous categories d'une categorie" et "toutes les categories"
        /// </summary>
        /// <param name="id">id d'une categorie, si il est null le cas "tous les produits" a été cliqué</param>
        /// <returns></returns>
        public ActionResult ProduitsCategorie(string id)
        {
            var bci = new BreadCrumItem("Index Categories", "IndexCategories", "Catalogue");
            ListeBreadCrumItem.Add(bci);
            var svm = SearchViewModel.InitializeSVM();
            List<Produits> result=null;
            if (id !=null)
            {
                var idcat = Int32.Parse(id);

                svm.idCategories = new int[] { idcat };
                var sousCategories = db.SousCategories.Where(sc => sc.IdCategorie == idcat).Select(sc => sc.IdSousCategorie).ToList();
                result = db.Produits.Where(p =>sousCategories.Contains(p.IdSousCategorie)).ToList();
                bci = new BreadCrumItem(db.Categories.Where(sc => sc.IdCategorie == idcat).FirstOrDefault().Libelle, "", "");
                ListeBreadCrumItem.Add(bci);
            }
            else
            {
                result = db.Produits.ToList();
                svm.idCategories=null;
                bci = new BreadCrumItem("Tous les Produits", "", "");
                ListeBreadCrumItem.Add(bci);
            }
            svm.Prixmax = db.Produits.Max(p => p.Prix);

            var rvm = ResultViewModels.RvmCreate(svm, result);
            rvm.BackToSearch = false;
            return View("../Produit/Result", rvm);


        }
        /// <summary>
        /// public ActionResult ProduitsSousCategorie(string id)
        /// retourne la liste des produits d'une sous catégorie donnée
        /// </summary>
        /// <param name="id">identifiant de la sous categorie concernée</param>
        /// <returns>liste des produits de la sous categorie</returns>
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