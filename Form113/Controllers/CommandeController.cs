using Form113.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form113.Controllers
{
    public class CommandeController : BestArtController
    {

        public CommandeController()
        {
            var bci = new BreadCrumItem("Commande", "Index", "");
            ListeBreadCrumItem.Add(bci);
        }

        // GET: Commande
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Payment(CommandeViewModels cvm)
        {
            var str = cvm.ListeProduitCommande;

            return View("Result");
        }

        [HttpPost]
        public ActionResult PaymentAdresseVariable(CommandeViewModels cvm)
        {
            return View("Result");
        }
    }
}