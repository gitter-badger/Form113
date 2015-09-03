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
        private static BestArtEntities db = new BestArtEntities();

        public CommandeController()
        {
            var bci = new BreadCrumItem("Commande", "Index", "");
            ListeBreadCrumItem.Add(bci);
        }

        private CommandeViewModels InitCVM()
        {
            var cvm = new CommandeViewModels();
            cvm.RegionsDepartements = db.RegionsFR.OrderBy(r => r.Nom)
               .ToDictionary(r => r.Nom,
               r => r.Departements.OrderBy(d => d.Nom)
                   .ToDictionary(d => d.NumDep, d => d.Nom)
                   );
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

            // Commande . etatcommande a 1
            user.Commandes.Add(Commande);
            db.SaveChanges();
        }
        private void EnregistrementCommandesDetails(List<KeyValuePair<int, int>> listeRes, Commandes Commande, int? nombreCommande)
        {
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
                }
            }
        }
    }
}