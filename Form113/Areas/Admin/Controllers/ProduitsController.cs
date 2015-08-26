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
    public class ProduitsController : Controller
    {
        private BestArtEntities db = new BestArtEntities();

        // GET: Admin/Produits
        public ActionResult Index()
        {
            var produits = db.Produits.Include(p => p.Pays).Include(p => p.SousCategories);
            return View(produits.ToList());
        }

        // GET: Admin/Produits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produits produits = db.Produits.Find(id);
            if (produits == null)
            {
                return HttpNotFound();
            }
            return View(produits);
        }

        // GET: Admin/Produits/Create
        public ActionResult Create()
        {
            ViewBag.CodePays = new SelectList(db.Pays, "CodeIso3", "Name");
            ViewBag.IdSousCategorie = new SelectList(db.SousCategories, "IdSousCategorie", "Nom");
            return View();
        }

        // POST: Admin/Produits/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProduit,Nom,Couleur,Description,Prix,IdSousCategorie,DateMiseEnVente,Promotion,CodePays,Stock")] Produits produits)
        {
            if (ModelState.IsValid)
            {
                db.Produits.Add(produits);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodePays = new SelectList(db.Pays, "CodeIso3", "Name", produits.CodePays);
            ViewBag.IdSousCategorie = new SelectList(db.SousCategories, "IdSousCategorie", "Nom", produits.IdSousCategorie);
            return View(produits);
        }

        // GET: Admin/Produits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produits produits = db.Produits.Find(id);
            if (produits == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodePays = new SelectList(db.Pays, "CodeIso3", "Name", produits.CodePays);
            ViewBag.IdSousCategorie = new SelectList(db.SousCategories, "IdSousCategorie", "Nom", produits.IdSousCategorie);
            return View(produits);
        }

        // POST: Admin/Produits/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProduit,Nom,Couleur,Description,Prix,IdSousCategorie,DateMiseEnVente,Promotion,CodePays,Stock")] Produits produits)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produits).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodePays = new SelectList(db.Pays, "CodeIso3", "Name", produits.CodePays);
            ViewBag.IdSousCategorie = new SelectList(db.SousCategories, "IdSousCategorie", "Nom", produits.IdSousCategorie);
            return View(produits);
        }

        // GET: Admin/Produits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produits produits = db.Produits.Find(id);
            if (produits == null)
            {
                return HttpNotFound();
            }
            return View(produits);
        }

        // POST: Admin/Produits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produits produits = db.Produits.Find(id);
            db.Produits.Remove(produits);
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
