using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestDrivenDogs
{
    public class DogsController : BaseController
    {
        public ActionResult Index()
        {
            return View(Context.Dogs.ToList());
        }

		public ActionResult New() {
			return View(new Dog());
		}

		public ActionResult Create(Dog dog) {
			Context.Dogs.Add(dog);
			Context.SaveChanges();
			return RedirectToAction("Index");
		}
    }
}
