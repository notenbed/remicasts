using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TestDrivenDogs.Specs.Web {

	[TestFixture]
	public class ManagingDogsSpec : WebSpec {

		[Test]
		public void can_view_list_of_dogs() {
			Visit("/");
			Click("Dogs");
			Page.Body.ShouldNotContain("Awesome Rover");

			var db    = new DogsContext();
			var rover = new Dog {
				Name  = "Awesome Rover",
				Breed = "Golden Retriever",
				VetId = 5,
				RegisteredAt = DateTime.Now,
				UniqueId     = Guid.NewGuid()
			};
			db.Dogs.Add(rover);
			db.SaveChanges();

			Refresh();
			Page.Body.ShouldContain("Awesome Rover");
		}

		[Test]
		public void can_create_dog() {
			var db = new DogsContext();
			db.Dogs.Count().ShouldEqual(0);

			Visit("/");
			Click("Dogs");
			Click("Add Dog");
			FillIn("Name", "Awesome Spot");
			FillIn("Breed", "Golden Retriever");
			FillIn("VetId", "5");
			FillIn("RegisteredAt", DateTime.Now.ToString());
			FillIn("UniqueId", Guid.NewGuid().ToString());
			Click("Create");

			db.Dogs.Count().ShouldEqual(1);
			db.Dogs.First().Name.ShouldEqual("Awesome Spot");
		}

		[Test]
		public void cant_create_invalid_dog() {
			var db = new DogsContext();
			db.Dogs.Count().ShouldEqual(0);

			Visit("/");
			Click("Dogs");
			Click("Add Dog");
			FillIn("Name", string.Empty);
			Click("Create");

			db.Dogs.Count().ShouldEqual(0);
			Page.Body.ShouldContain("The Name field is required.");
		}
	}
}
