using System;
using System.Web;
using Owin;

namespace WebApps {

	public class WrapBodyWith : Application, IApplication, IMiddleware {
		public WrapBodyWith(string text) {
			Text = text;
		}

		public string Text;

		public override IResponse Call(IRequest request) {
			if (request.Uri == "/boom")
				throw new Exception("BOOM!");
			else if (request.Uri == "/bad")
				return new Response().SetBody(5);

			var response = Application.GetResponse(InnerApplication, request);
			response.BodyText = Text + response.BodyText + Text;
			return response;
		}
	}

	public class MyAppHandler : AspNetApplication, IApplication, IHttpHandler {
		static IApplication app = new Builder().
						Use(new ShowExceptions()).
						Use(new Lint()).
						Use(new WrapBodyWith("first")).
						Use(new WrapBodyWith("second")).
						Use(new WrapBodyWith("third")).
						Run(new MyApp()).
						ToApp();

		public override IResponse Call(IRequest request) {
			return Application.Invoke(app, request);
		}
	}
}
