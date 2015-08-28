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
        private static BestArtEntities db = new BestArtEntities();

        public JsonResult GetJSONPROD(string id)
        {
            int idtempo = int.Parse(id);
            var LR = db.Produits.Where(p => p.IdProduit == idtempo)
                               .Select(p => new { prod = p.Nom , prix = p.Prix })
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
            return View();
        }
    }
}