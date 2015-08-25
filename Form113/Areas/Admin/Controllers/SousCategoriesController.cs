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
    public class SousCategoriesController : Controller
    {
        private BestArtEntities db = new BestArtEntities();

        // GET: Admin/SousCategories
        public ActionResult Index()
        {
            var sousCategories = db.SousCategories.Include(s => s.Categories);
            return View(sousCategories.ToList());
        }

        // GET: Admin/SousCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SousCategories sousCategories = db.SousCategories.Find(id);
            if (sousCategories == null)
            {
                return HttpNotFound();
            }
            return View(sousCategories);
        }

        // GET: Admin/SousCategories/Create
        public ActionResult Create()
        {
            ViewBag.IdCategorie = new SelectList(db.Categories, "IdCategorie", "Libelle");
            return View();
        }

        // POST: Admin/SousCategories/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSousCategorie,Nom,IdCategorie")] SousCategories sousCategories)
        {
            if (ModelState.IsValid)
            {
                db.SousCategories.Add(sousCategories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCategorie = new SelectList(db.Categories, "IdCategorie", "Libelle", sousCategories.IdCategorie);
            return View(sousCategories);
        }

        // GET: Admin/SousCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SousCategories sousCategories = db.SousCategories.Find(id);
            if (sousCategories == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCategorie = new SelectList(db.Categories, "IdCategorie", "Libelle", sousCategories.IdCategorie);
            return View(sousCategories);
        }

        // POST: Admin/SousCategories/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSousCategorie,Nom,IdCategorie")] SousCategories sousCategories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sousCategories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategorie = new SelectList(db.Categories, "IdCategorie", "Libelle", sousCategories.IdCategorie);
            return View(sousCategories);
        }

        // GET: Admin/SousCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SousCategories sousCategories = db.SousCategories.Find(id);
            if (sousCategories == null)
            {
                return HttpNotFound();
            }
            return View(sousCategories);
        }

        // POST: Admin/SousCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SousCategories sousCategories = db.SousCategories.Find(id);
            db.SousCategories.Remove(sousCategories);
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
