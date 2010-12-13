using System;
using Owin;

namespace WebApps {
	public class MyApp : Application, IApplication {
		public override IResponse Call(IRequest request) {
			var response = new Response();

			response.Write("I am MyApp!  You requested {0} {1}",
				request.Method, request.Uri);

			return response;
		}
	}
}
