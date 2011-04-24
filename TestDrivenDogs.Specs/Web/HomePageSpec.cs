using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TestDrivenDogs.Specs.Web {

	[TestFixture]
	public class HomePageSpec : WebSpec {

		[Test]
		public void should_display_application_title() {
			Visit("/");
			Page.Body.ShouldContain("Test-Driven Dogs");
		}
	}
}
