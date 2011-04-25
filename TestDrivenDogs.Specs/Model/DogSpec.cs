using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Model.IsValid;

namespace TestDrivenDogs.Specs.Model {
	
	[TestFixture]
	public class DogSpec : ModelSpec {

		[Test]
		public void requires_name() {
			var dog = new Dog { Name = null };

			dog.IsValid().Should(Be.False);
			dog.ErrorMessagesFor("Name").ShouldContain("The Name field is required.");

			dog.Name = "Awesome Rover";
			dog.IsValid().Should(Be.True);
		}

		[Test]
		public void requires_name_to_be_awesome() {
			var dog = new Dog { Name = "Rover" };

			dog.IsValid().Should(Be.False);
			dog.ErrorMessagesFor("Name").ShouldContain("Name must be awesome!");

			dog.Name = "Awesome Rover";
			dog.IsValid().Should(Be.True);
		}

		[Test]
		public void requires_unique_name() {
			var rover1 = new Dog { Name = "Awesome Rover" };
			Context.Dogs.Add(rover1);
			Context.SaveChanges();
			Context.Dogs.Count().ShouldEqual(1);

			var rover2 = new Dog { Name = "Awesome Rover" };
			rover2.IsValid().Should(Be.False);
			rover2.ErrorMessagesFor("Name").ShouldContain("Name already taken");

			var spot = new Dog { Name = "Awesome Spot" };
			spot.IsValid().Should(Be.True);
		}
	}
}
