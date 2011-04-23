using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TestDrivenDogs.Specs {

	[TestFixture]
	public class HomePageSpec : Requestoring.Requestor {

		[Test]
		public void should_display_application_title() {
			Get("http://localhost:50486/");

			Console.WriteLine("Status: {0}", LastResponse.Status);
			Console.WriteLine("Body: {0}", LastResponse.Body);
			foreach (var header in LastResponse.Headers)
				Console.WriteLine("{0}: {1}", header.Key, header.Value);
		}
	}
}
