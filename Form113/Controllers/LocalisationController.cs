using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form113.Controllers
{
    public class LocalisationController : Controller
    {
        private static BestArtEntities db = new BestArtEntities();

        public JsonResult GetJSONREG(string id)
        {
            int idtempo = int.Parse(id);
            var LR = db.Regions.Where(r => r.idContinent == idtempo)
                               .OrderBy(r => r.name)
                               .Select(r => new { nr = r.idRegion, reg = r.name })
                               .ToList();
            return Json(LR, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetJSONPAYS(string id)
        {
            int idtempo = int.Parse(id);
            var LD = db.Pays.Where(p => p.idRegion == idtempo)
                                    .OrderBy(p => p.Name)
                                    .Select(p => new { np = p.CodeIso3, pay = p.Name })
                                    .ToList();
            return Json(LD, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetJSONVILLE(string id)
        {
            
            var LV = db.Villes.Where(v => v.NumDep == id)
                                    .OrderBy(v=>v.Nom)
                                    .Select(v => new { idv = v.CodeINSEE, nom=v.Nom })
                                    .ToList();
            return Json(LV, JsonRequestBehavior.AllowGet);
        }
    }
}