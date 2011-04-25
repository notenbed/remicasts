using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Model.IsValid;

namespace TestDrivenDogs.Specs.Model {
	
	[TestFixture]
	public class DogSpec {

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
	}
}
