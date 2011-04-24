using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TestDrivenDogs {
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication {
		public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
			filters.Add(new HandleErrorAttribute());
		}

		public static void RegisterRoutes(RouteCollection routes) {
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
			);

		}

		protected void Application_Start() {
			AreaRegistration.RegisterAllAreas();

			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);
		}

		static DogsContext _DogsContext;

		/// <summary>Returns the current DogsContext for the current request (using HttpContext.Current.Items for thread safety)</summary>
		/// <remarks>
		/// From the tests (or elsewhere), you can set this property manually to override it.
		/// It it's not set, we lazily initialize a new DogsContext for the current HttpContext.
		/// 
		/// </remarks>
		public static DogsContext CurrentDogsContext {
			get {
				// If the context was overriden, return it!
				// This allows us to override the context (eg. from tests)
				if (_DogsContext != null)
					return _DogsContext;

				// Generate a dictionary key for this context, specific to the current request
				// HashCode is used to ensure correct instance of HttpContext.
				var key = HttpContext.Current.GetHashCode().ToString("x") + "_DogsContext";

				// Instantiates a new context for this request, if it doesn't exist.
				if (! HttpContext.Current.Items.Contains(key))
					HttpContext.Current.Items[key] = new DogsContext();

				return HttpContext.Current.Items[key] as DogsContext;
			}
			set { _DogsContext = value; }
		}
	}
}