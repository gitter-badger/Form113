using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form113.Controllers
{
    public class JsonController : Controller
    {
        private BestArtEntities db = new BestArtEntities();
        // GET: Json
        public ActionResult Index()
        {
            return View();
        }



        public JsonResult CheckEmail(string email)
        {

            bool test = (db.Utilisateurs.Where(u => u.Identites.Email == email).Count() == 0);

            var result = test;
            return Json(result, JsonRequestBehavior.AllowGet);

        }
    }
}