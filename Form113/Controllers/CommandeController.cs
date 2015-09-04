using DataLayer.Models;
using Form113.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form113.Controllers
{
    [Authorize]
    public class CommandeController : BestArtController
    {
        public CommandeController()
        {
            var bci = new BreadCrumItem("Commande", "Index", "");
            ListeBreadCrumItem.Add(bci);
        }

        private CommandeViewModels InitCVM()
        {
            var db = new BestArtEntities();

            var cvm = new CommandeViewModels();
            cvm.RegionsDepartements = db.RegionsFR.OrderBy(r => r.Nom)
               .ToDictionary(r => r.Nom,
               r => r.Departements.OrderBy(d => d.Nom)
                   .ToDictionary(d => d.NumDep, d => d.Nom)
                   );
            
            cvm.NbCommande = 0;
            cvm.NbCommandeFid = db.Marketing.Select(m => m.NbreCommandePourReduc).FirstOrDefault();

            if (User.Identity.IsAuthenticated)
            {
                var iduserASP = db.AspNetUsers.Where(x => x.Email == User.Identity.Name).Select(x => x.Id).FirstOrDefault();
                var user = db.Utilisateurs.Where(x => x.IdAsp == iduserASP).FirstOrDefault();
                cvm.NbCommande = user.NbCommande ?? 0;
            }
            return cvm;
        }

        // GET: Commande
        public ActionResult Index()
        {
            var cvm = InitCVM();
            return View(cvm);
        }


        [HttpPost]
        public ActionResult Payement(CommandeViewModels cvm)
        {
            EnregistrementPayment(cvm);
            return View("Result");
        }

        private void EnregistrementPayment(CommandeViewModels cvm)
        {
            var db = new BestArtEntities();

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
            var user = db.Utilisateurs.Where(x => x.IdAsp == iduserASP).FirstOrDefault();
            var Commande = new Commandes();
            Commande.DateCommande = DateTime.Now;

            if (cvm.Adresse1 != null) // Adresse de livraison diferrente de celle du client
            {
                var ville = db.Villes.Where(v => v.CodeINSEE == cvm.CodeVille).FirstOrDefault();
                var CP = ville.ZipCodes.FirstOrDefault().CodePostal;

                var AdresseIdToSave = db.Adresses.Where(a => a.CodeINSEE == ville.CodeINSEE)
                                                     .Where(a => a.CodePostal == CP)
                                                     .Where(a => a.Ligne1 == cvm.Adresse1)
                                                     .Where(a => a.Ligne2 == cvm.Adresse2)
                                                     .Where(a => a.Ligne3 == cvm.Adresse3)
                                                     .Select(a => a.IdAdresse)
                                                     .FirstOrDefault();
                if (AdresseIdToSave != 0)
                {
                    Commande.IdAdresse = AdresseIdToSave;
                }
                else
                {
                    var Adresse = new Adresses()
                    {
                        Ligne1 = cvm.Adresse1,
                        Ligne2 = cvm.Adresse2,
                        Ligne3 = cvm.Adresse3,
                        CodeINSEE = ville.CodeINSEE,
                        CodePostal = CP,
                    };
                    db.Adresses.Add(Adresse);
                    db.SaveChanges();
                    Commande.IdAdresse = Adresse.IdAdresse;
                }
            }
            else // Adresse de livraison etant celle du client
            {
                Commande.IdAdresse = db.Utilisateurs.Where(u => u.IdUtilisateur == user.IdUtilisateur).Select(x => x.IdAdresse).FirstOrDefault();
            }

            user.NbCommande = db.Commandes.Where(c => c.IdAcheteur == user.IdUtilisateur).Count() + 1;

            EnregistrementCommandesDetails(listeRes, Commande, user.NbCommande);

            Commande.StatusCommande = db.StatusCommande.Where(x => x.IdStatusCommande == 1).FirstOrDefault();
            user.Commandes.Add(Commande);
            db.SaveChanges();
        }
        private void EnregistrementCommandesDetails(List<KeyValuePair<int, int>> listeRes, Commandes Commande, int? nombreCommande)
        {
            var db = new BestArtEntities();

            var NbPourReduc = db.Marketing.Select(m => m.NbreCommandePourReduc).FirstOrDefault();
            if (nombreCommande != null && nombreCommande >= NbPourReduc)
            {
                foreach (var item in listeRes)
                {
                    var prix = db.Produits.Where(p => p.IdProduit == item.Key).Select(p => p.Prix).FirstOrDefault();

                    var OrderDetail = new Commandes_details()
                    {
                        IdProduit = item.Key,
                        quantite = item.Value,
                        Promotion = db.Produits.Where(p => p.IdProduit == item.Key).Select(p => p.Promotion).FirstOrDefault(),
                        prix_unitaire = prix - (prix * (10 / 100)),
                    };
                    Commande.Commandes_details.Add(OrderDetail);

                    // --- Gestion des stocks lors de la validation commande
                    var produit = db.Produits.Find(item.Key);
                    produit.Stock -= item.Value;
                    db.Entry(produit).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                }
            }
            else
            {
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
                    // --- Gestion des stocks lors de la validation commande
                    var produit = db.Produits.Find(item.Key);
                    produit.Stock -= item.Value;
                    db.Entry(produit).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }
    }
}