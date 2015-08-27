using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer.Models;
using System.IO;

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
        public ActionResult Create([Bind(Include = "IdProduit,Nom,Couleur,Description,Prix,IdSousCategorie,DateMiseEnVente,Promotion,CodePays,Stock")] Produits produits, HttpPostedFileBase[] file)
        {
            if (ModelState.IsValid)
            {
                db.Produits.Add(produits);
                db.SaveChanges();
                if (!(file.Count() == 0))
                {
                    for (int i = 0; i < file.Count(); i++)
                    {
                        var fileName = Path.GetFileName(file[i].FileName);
                        var path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                        var photo = new DataLayer.Models.Photos();
                        photo.IdProduit = produits.IdProduit;
                        photo.PhotoName = fileName.ToString();
                        db.Photos.Add(photo);
                        db.SaveChanges();
                    }
                }
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

        /// <summary>
        /// Permet de modifier la photo d'un seul produit
        /// </summary>
        /// <param name="id">IdPhoto</param>
        /// <param name="id2">IdProduit</param>
        /// <returns></returns>
        public ActionResult ModifPhotos(string id, string id2)
        {
            int IdProduit = int.Parse(id2);
            int IdPhoto = int.Parse(id);
            var Photo = new DataLayer.Models.Photos(); 
            if (IdPhoto == 0)
            {
                // Il n'y a pas de photo donc il faut creer la photo dans la base de donnée
                var photo = new DataLayer.Models.Photos();
                photo.IdProduit = IdProduit;
                photo.PhotoName = "pagenotfound_icon.png";
                db.Photos.Add(photo);
                db.SaveChanges();
                IdPhoto = photo.IdPhoto;
            }
            Photo = db.Photos.Where(c => c.IdProduit == IdProduit && c.IdPhoto == IdPhoto)
                    .First();
            return View(Photo);
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
        // Modification des Photos


        // Partie Des vues partielles =======
        [ChildActionOnly]
        public PartialViewResult PhotoProduit(string id)
        {
            int idProduit = int.Parse(id);
            List<DataLayer.Models.Photos> listPhoto = db.Photos.Where(c => c.IdProduit == idProduit).ToList();
            if (listPhoto.Count()==0)
            {
                var photoNotFound = new DataLayer.Models.Photos();
                photoNotFound.PhotoName = "pagenotfound_icon.png";
                photoNotFound.IdProduit = idProduit;
                var listPhoto2 = new List<DataLayer.Models.Photos>();
                listPhoto2.Add(photoNotFound);
                listPhoto = listPhoto2;               
            }
            return PartialView("_PhotoProduit",listPhoto);
        }
        [HttpPost]
        public ActionResult SaveModifiedPic([Bind(Include="IdPhoto,IdProduit")] Photos photo,HttpPostedFileBase file)
        {
            bool pictureValide = true;
            if (file == null || file.ContentLength <= 0)
            {
                pictureValide = false;
            }
            var fileName = Path.GetFileName(file.FileName);
            if (fileName == null)
            {
                pictureValide = false;
            }
            if (pictureValide==true)
            {
                var path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                file.SaveAs(path);
                photo.PhotoName = file.FileName;
                db.Entry(photo).State = EntityState.Modified;
                db.SaveChanges();
                var produit = db.Produits.Where(c => c.IdProduit == photo.IdProduit).FirstOrDefault();
                return View("Details",produit);
            }
           
            return View("Index");
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
