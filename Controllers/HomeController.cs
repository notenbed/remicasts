using System;
using System.Web.Mvc;

namespace ExampleSite {
	public class HomeController : BaseController {

		// GET /
		public ActionResult Index() {
			if (LoggedIn)
				return View("LoggedIn");
			else
				return View("LoggedOut");
		}

		// GET /login
		public ActionResult Login(User user) {
			LoginAs(user);
			return RedirectToRoute("Default");
		}

		// GET /logout
		public ActionResult Logout() {
			ResetSession();
			return RedirectToRoute("Default");
		}
	}
}
