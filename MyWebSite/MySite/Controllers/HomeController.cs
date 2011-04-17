using System;
using System.Web.Mvc;

namespace MySite {
	public class HomeController : Controller {
		public ActionResult Index() {
			return View();
		}
	}
}
