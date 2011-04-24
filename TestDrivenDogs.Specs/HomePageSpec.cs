using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TestDrivenDogs.Specs {

	[SetUpFixture]
	public class SpecSetup {
		[SetUp]
		public void BeforeAll() {
			
		}
		[TearDown]
		public void AfterAll() {

		}
	}

	[TestFixture]
	public class HomePageSpec : Mara.MaraTest {

		[SetUp]
		public void Before() {
			new DogsContext().Database.ExecuteSqlCommand("DELETE FROM Dogs");
			CurrentDriver = new Mara.Drivers.WebClient();
			Root          = "http://tdd-dogs";
		}

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
