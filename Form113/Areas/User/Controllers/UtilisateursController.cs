using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer.Models;
using Form113.Models;
using Form113.Controllers;

namespace Form113.Areas.User.Controllers
{
    public class UtilisateursController : BestArtController
    {
        private BestArtEntities db = new BestArtEntities();

        // GET: User/Utilisateurs
        public ActionResult Index()
        {
            var utilisateurs = db.Utilisateurs.Include(u => u.Adresses).Include(u => u.AspNetUsers).Include(u => u.Identites);
            return View(utilisateurs.ToList());
        }

        // GET: User/Utilisateurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateurs utilisateurs = db.Utilisateurs.Find(id);
            if (utilisateurs == null)
            {
                return HttpNotFound();
            }
            return View(utilisateurs);
        }

        // GET: User/Utilisateurs/Create
        public ActionResult Create()
        {
            ViewBag.IdAdresse = new SelectList(db.Adresses, "IdAdresse", "Ligne1");
            ViewBag.IdAsp = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.IdIdentite = new SelectList(db.Identites, "IdIdentite", "Nom");
            return View();
        }

        // POST: User/Utilisateurs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUtilisateur,IdAsp,IdAdresse,NbCommande,DateInscription,LastConnection,IdIdentite")] Utilisateurs utilisateurs)
        {
            if (ModelState.IsValid)
            {
                db.Utilisateurs.Add(utilisateurs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAdresse = new SelectList(db.Adresses, "IdAdresse", "Ligne1", utilisateurs.IdAdresse);
            ViewBag.IdAsp = new SelectList(db.AspNetUsers, "Id", "Email", utilisateurs.IdAsp);
            ViewBag.IdIdentite = new SelectList(db.Identites, "IdIdentite", "Nom", utilisateurs.IdIdentite);
            return View(utilisateurs);
        }

        // GET: User/Utilisateurs/Edit/5
        public ActionResult Edit(string email)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //AspNetUsers utilisateurs = db.Utilisateurs.Find(id);
            //if (utilisateurs == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.IdAdresse = new SelectList(db.Adresses, "IdAdresse", "Ligne1", utilisateurs.IdAdresse);
            //ViewBag.IdAsp = new SelectList(db.AspNetUsers, "Id", "Email", utilisateurs.IdAsp);
            //ViewBag.IdIdentite = new SelectList(db.Identites, "IdIdentite", "Nom", utilisateurs.IdIdentite);
            //return View(utilisateurs);
            Utilisateurs user = db.Utilisateurs.Where(u => u.AspNetUsers.Email == email).First();
            var bci = new BreadCrumItem("Modification de profil", "", "");
            ListeBreadCrumItem.Add(bci);
            EditViewModel evm = new EditViewModel();
            evm.Adresse1 = user.Adresses.Ligne1;
            evm.Adresse2 = user.Adresses.Ligne2;
            evm.Adresse3 = user.Adresses.Ligne3;
            evm.CodeVille = db.Villes.Where(v=>v.CodeINSEE==user.Adresses.CodeINSEE).First().Nom;
            evm.Email = user.AspNetUsers.Email;
            evm.Nom = user.Identites.Nom;
            evm.iddep = db.Villes.Where(v => v.CodeINSEE == user.Adresses.CodeINSEE).First().NumDep;
            evm.Prenom = user.Identites.Prenom;
            evm.RegionsDepartements = db.RegionsFR.OrderBy(r => r.Nom)
               .ToDictionary(r => r.Nom,
               r => r.Departements.OrderBy(d => d.Nom)
                   .ToDictionary(d => d.NumDep, d => d.Nom)
                   );
            return View(evm);
        }

        // POST: User/Utilisateurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUtilisateur,IdAsp,IdAdresse,NbCommande,DateInscription,LastConnection,IdIdentite")] Utilisateurs utilisateurs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utilisateurs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAdresse = new SelectList(db.Adresses, "IdAdresse", "Ligne1", utilisateurs.IdAdresse);
            ViewBag.IdAsp = new SelectList(db.AspNetUsers, "Id", "Email", utilisateurs.IdAsp);
            ViewBag.IdIdentite = new SelectList(db.Identites, "IdIdentite", "Nom", utilisateurs.IdIdentite);
            
            return View(utilisateurs);
        }

        // GET: User/Utilisateurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateurs utilisateurs = db.Utilisateurs.Find(id);
            if (utilisateurs == null)
            {
                return HttpNotFound();
            }
            return View(utilisateurs);
        }

        // POST: User/Utilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utilisateurs utilisateurs = db.Utilisateurs.Find(id);
            db.Utilisateurs.Remove(utilisateurs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
