using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    /// <summary>
    /// Class permattant de récuperer les infos commande 
    /// </summary>
    public class Commande
    {
        #region Public
        public string Nom;
        public string Prenom;
        public DateTime OrderDate;
        public int OrderAge;
        public float TotalCommande;
        public string CommandeStatus;
        public int IdAcheteur;
        public int IdCommande;
        #endregion

        private BestArtEntities db = new BestArtEntities();

        public Commande(Models.Commandes commande)
        {
            // Recherche du nom et du prenom
            var utilisateur = db.Utilisateurs.Find(commande.IdAcheteur);
            var identities = db.Identites.Find(utilisateur.IdIdentite);
            Nom = identities.Nom;
            Prenom = identities.Prenom;
            // Calcul au niveau de la date
            OrderDate = commande.DateCommande.GetValueOrDefault(DateTime.Today);
            OrderAge = (int)(OrderDate-DateTime.Now).TotalDays ;

            // calcul de la somme
            TotalCommande = giveSummeCommande(commande);
            CommandeStatus = commande.StatusCommande.StatusCommande1;

            // Recupération des ID important
            IdAcheteur = utilisateur.IdUtilisateur;
            IdCommande = commande.IdCommande;
        }

        private float giveSummeCommande(Models.Commandes commande)
        {
            var commandeDetail = db.Commandes_details.Where(c => c.IdCommande == commande.IdCommande).ToList();
            float sumToMe = 0;
            foreach(var item in commandeDetail)
            {
                var _prix = item.Produits.Prix ;
                int _nbre = item.quantite ?? 0;
                sumToMe += (float)(_prix * _nbre);
            }
            return sumToMe;
        }
        public static List<Commande> giveMeList()
        {
            var db = new BestArtEntities();
            var listCommande = new List<Commande>();
            var collection = db.Commandes;
            foreach(var item in collection)
            {
                var comm = new Commande(item);
                listCommande.Add(comm);
            }
            return listCommande;
        }
    }
}
