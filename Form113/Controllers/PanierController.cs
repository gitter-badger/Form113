using DataLayer.Models;
using Form113.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form113.Controllers
{
    public class PanierController : BestArtController
    {
        public JsonResult GetJSONPROD(string id)
        {
            var db = new BestArtEntities();

            int idtempo = int.Parse(id);
            var LR = db.Produits.Where(p => p.IdProduit == idtempo)
                               .Select(p => new { prod = p.Nom, prix = p.Prix })
                               .FirstOrDefault();
            return Json(LR, JsonRequestBehavior.AllowGet);
        }

        public PanierController()
        {
            var bci = new BreadCrumItem("Panier", "Index", "");
            ListeBreadCrumItem.Add(bci);
        }

        // GET: Panier
        public ActionResult Index()
        {
            var db = new BestArtEntities(); //obligattion de crée une nouvelle connexion a chaque fois car sinon la mise a jour des donnée utilisateur ne ce fait aps

            var pvm = new PanierViewModels()
            {
                NbCommande = 0,
                NbCommandeFid = db.Marketing.Select(m => m.NbreCommandePourReduc).FirstOrDefault(),
            };

            if (User.Identity.IsAuthenticated)
            {
                var iduserASP = db.AspNetUsers.Where(x => x.Email == User.Identity.Name).Select(x => x.Id).FirstOrDefault();
                var user = db.Utilisateurs.Where(x => x.IdAsp == iduserASP).FirstOrDefault();
                pvm.NbCommande = user.NbCommande ?? 0;
            }


            return View(pvm);
        }
    }
}