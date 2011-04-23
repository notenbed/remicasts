using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TestDrivenDogs.Specs {

	[TestFixture]
	public class HomePageSpec : Mara.MaraTest {

		[Test]
		public void should_display_application_title() {
			CurrentDriver = new Mara.Drivers.WebClient();
			Visit("http://localhost:50486/");
			Page.Body.ShouldContain("Test-Driven Dogs");
		}
	}
}
