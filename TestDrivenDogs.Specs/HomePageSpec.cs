using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TestDrivenDogs.Specs {

	[TestFixture]
	public class HomePageSpec : WebSpec {

		[Test]
		public void should_display_application_title() {
			Visit("/");
			Page.Body.ShouldContain("Test-Driven Dogs");
		}

		[Test]
		public void can_view_list_of_dogs() {
			Visit("/");
			Click("Dogs");
			Page.Body.ShouldNotContain("Rover");

			var db    = new DogsContext();
			var rover = new Dog { Name = "Rover" };
			db.Dogs.Add(rover);
			db.SaveChanges();

			Refresh();
			Page.Body.ShouldContain("Rover");
		}

		[Test]
		public void can_create_dog() {
			var db = new DogsContext();
			db.Dogs.Count().ShouldEqual(0);

			Visit("/");
			Click("Dogs");
			Click("Add Dog");
			FillIn("Name", "Spot");
			Click("Create");

			db.Dogs.Count().ShouldEqual(1);
			db.Dogs.First().Name.ShouldEqual("Spot");
		}
	}
}
