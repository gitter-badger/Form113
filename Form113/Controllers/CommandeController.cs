using DataLayer.Models;
using Form113.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form113.Controllers
{
    public class CommandeController : BestArtController
    {
        private static BestArtEntities db = new BestArtEntities();

        public CommandeController()
        {
            var bci = new BreadCrumItem("Commande", "Index", "");
            ListeBreadCrumItem.Add(bci);
        }

        // GET: Commande
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Payment(CommandeViewModels cvm)
        {
            var str = cvm.ListeProduitCommande;
            var liste = str.Split('/');
            var listeRes = new List<KeyValuePair<int, int>>();
            foreach (var item in liste)
            {
                var tempo = item.Split(',');
                var kvp = new KeyValuePair<int, int>(int.Parse(tempo[0]), int.Parse(tempo[1]));
                listeRes.Add(kvp);
            }

            var iduserASP = db.AspNetUsers.Where(x => x.Email == User.Identity.Name).Select(x => x.Id).FirstOrDefault();
            int iduser = db.Utilisateurs.Where(x => x.IdAsp == iduserASP).Select(x => x.IdUtilisateur).FirstOrDefault();
            var Commande = new Commandes()
            {
                DateCommande = DateTime.Now,
                EtatCommande = "0",
                IdAcheteur = iduser,
                IdAdresse = db.Utilisateurs.Where(u => u.IdUtilisateur == iduser).Select(x => x.IdAdresse).FirstOrDefault(),
            };

            foreach (var item in listeRes)
            {
                var OrderDetail = new Commandes_details()
                {
                    IdProduit = item.Key,
                    quantite = item.Value,
                    Promotion = db.Produits.Where(p => p.IdProduit == item.Key).Select(p => p.Promotion).FirstOrDefault(),
                    prix_unitaire = db.Produits.Where(p => p.IdProduit == item.Key).Select(p => p.Prix).FirstOrDefault(),
                };
                Commande.Commandes_details.Add(OrderDetail);
            }
            db.Commandes.Add(Commande);
            db.SaveChanges();
            return View("Result");
        }

        [HttpPost]
        public ActionResult PaymentAdresseVariable(CommandeViewModels cvm)
        {
            return View("Result");
        }
    }
}