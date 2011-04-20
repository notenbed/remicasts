using System;
using System.Web.Mvc;
using TheFlash;

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
			this.Flash("You gotted logged in!");
			return RedirectToRoute("Default");
		}

		// GET /logout
		public ActionResult Logout() {
			ResetSession();
			this.Flash("Thank you!  Come again!");
			return RedirectToRoute("Default");
		}
	}
}
