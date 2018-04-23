using System;
using System.Linq;
using System.Web.Mvc;
using EF.Models;

namespace EF.Controllers {
    public class EFGridModeController : Controller {
        NorthwindContext db = new NorthwindContext();

        public ActionResult Index() {
            return View();
        }
        
        public ActionResult GridViewPartial() {
            return PartialView(db.Orders.ToList());
        }
    }
}