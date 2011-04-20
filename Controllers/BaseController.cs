using System;
using System.Web.Mvc;

namespace ExampleSite {
	public class BaseController : Controller {

		public void LoginAs(User user) {
			Session["LoggedIn"] = true;
		}

		public void ResetSession() {
			Session.Clear();
		}

		public bool LoggedIn {
			get { return Session["LoggedIn"] != null && (bool) Session["LoggedIn"] == true; }
		}
	}
}
