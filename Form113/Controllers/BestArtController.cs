using Form113.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form113.Controllers
{
    public class BestArtController : Controller
    {
        public List<BreadCrumItem> ListeBreadCrumItem = new List<BreadCrumItem>();

        public BestArtController()
        {
            var bci = new BreadCrumItem("Home", "Index", "Home");
            ListeBreadCrumItem.Add(bci);
            ViewBag.BreadCrum = ListeBreadCrumItem;
        }
    }
}