using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer.Models;

namespace Form113.Areas.Admin.Controllers
{
    public class CommandesController : Controller
    {
        private BestArtEntities db = new BestArtEntities();

        // GET: Admin/Commandes
        public ActionResult Index()
        {
            var listCommande = DataLayer.Commande.giveMeList();
            return View(listCommande);
            // Automatic code
            //var commandes = db.Commandes.Include(c => c.Utilisateurs).Include(c => c.StatusCommande);
            //return View(commandes.ToList());
        }

        // GET: Admin/Commandes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commandes commandes = db.Commandes.Find(id);
            if (commandes == null)
            {
                return HttpNotFound();
            }
            return View(commandes);
        }

        // GET: Admin/Commandes/Create
        public ActionResult Create()
        {
            ViewBag.IdAcheteur = new SelectList(db.Utilisateurs, "IdUtilisateur", "IdAsp");
            ViewBag.EtatCommande = new SelectList(db.StatusCommande, "IdStatusCommande", "StatusCommande1");
            return View();
        }

        // POST: Admin/Commandes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCommande,IdAcheteur,EtatCommande,DateCommande,DateLivraison,IdAdresse")] Commandes commandes)
        {
            if (ModelState.IsValid)
            {
                db.Commandes.Add(commandes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAcheteur = new SelectList(db.Utilisateurs, "IdUtilisateur", "IdAsp", commandes.IdAcheteur);
            ViewBag.EtatCommande = new SelectList(db.StatusCommande, "IdStatusCommande", "StatusCommande1", commandes.EtatCommande);
            return View(commandes);
        }

        // GET: Admin/Commandes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commandes commandes = db.Commandes.Find(id);
            if (commandes == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAcheteur = new SelectList(db.Utilisateurs, "IdUtilisateur", "IdAsp", commandes.IdAcheteur);
            ViewBag.EtatCommande = new SelectList(db.StatusCommande, "IdStatusCommande", "StatusCommande1", commandes.EtatCommande);
            return View(commandes);
        }

        // POST: Admin/Commandes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCommande,IdAcheteur,EtatCommande,DateCommande,DateLivraison,IdAdresse")] Commandes commandes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commandes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAcheteur = new SelectList(db.Utilisateurs, "IdUtilisateur", "IdAsp", commandes.IdAcheteur);
            ViewBag.EtatCommande = new SelectList(db.StatusCommande, "IdStatusCommande", "StatusCommande1", commandes.EtatCommande);
            return View(commandes);
        }

        // GET: Admin/Commandes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commandes commandes = db.Commandes.Find(id);
            if (commandes == null)
            {
                return HttpNotFound();
            }
            return View(commandes);
        }

        // POST: Admin/Commandes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Commandes commandes = db.Commandes.Find(id);
            db.Commandes.Remove(commandes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [ChildActionOnly]
        public PartialViewResult Adresse(int id)
        {
            var adresse = db.Adresses.Find(id);
            return PartialView("_Adresse",adresse);
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
