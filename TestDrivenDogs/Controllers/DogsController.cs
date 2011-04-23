using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestDrivenDogs
{
    public class DogsController : Controller
    {
        //
        // GET: /Dogs/

        public ActionResult Index()
        {
            return View(new DogsContext().Dogs.ToList());
        }

		public ActionResult New() {
			return View(new Dog());
		}

		public ActionResult Create(Dog dog) {
			var db = new DogsContext();
			db.Dogs.Add(dog);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
    }
}
