using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form113.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Controller permettant d'afficher le nombre de produit, Dernier Produits, 
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public PartialViewResult HighlightedProduct()
        {
            return PartialView("_HighlightedProduct");
        }
    }
}