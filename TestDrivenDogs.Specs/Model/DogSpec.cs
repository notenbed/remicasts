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
		public void can_create_valid_dogs() {
			Context.Dogs.Count().ShouldEqual(0);
			for (int i = 0; i < 3; i++) {
				var dog = f.Dog.Build();
				Context.Dogs.Add(dog);
				Context.SaveChanges();
			}
			Context.Dogs.Count().ShouldEqual(3);
		}

		[Test]
		public void requires_name() {
			var dog = f.Dog.Build();
			dog.Name = null;

			dog.IsValid().Should(Be.False);
			dog.ErrorMessagesFor("Name").ShouldContain("The Name field is required.");

			dog.Name = "Awesome Rover";
			dog.IsValid().Should(Be.True);
		}

		[Test]
		public void requires_name_to_be_awesome() {
			var dog = f.Dog.Build();
			dog.Name = "Rover";

			dog.IsValid().Should(Be.False);
			dog.ErrorMessagesFor("Name").ShouldContain("Name must be awesome!");

			dog.Name = "Awesome Rover";
			dog.IsValid().Should(Be.True);
		}

		[Test]
		public void requires_unique_name() {
			var rover1 = f.Dog.Build();
			rover1.Name = "Awesome Rover";
			Context.Dogs.Add(rover1);
			Context.SaveChanges();
			Context.Dogs.Count().ShouldEqual(1);

			var rover2 = f.Dog.Build();
			rover2.Name = "Awesome Rover";
			rover2.IsValid().Should(Be.False);
			rover2.ErrorMessagesFor("Name").ShouldContain("Name already taken");

			var spot = f.Dog.Build();
			spot.Name = "Awesome Spot";
			spot.IsValid().Should(Be.True);
		}

		[Test]
		public void requires_breed() {
			var dog = f.Dog.Build();
			dog.Breed = null;
			dog.IsValid().Should(Be.False);

			dog.Breed = "Golden Retriever";
			dog.IsValid().Should(Be.True);
		}

		[Test]
		public void requires_vet_id() {
			var dog = f.Dog.Build();
			dog.VetId = null;
			dog.IsValid().Should(Be.False);

			dog.VetId = 5;
			dog.IsValid().Should(Be.True);
		}

		[Test]
		public void requires_registered_at() {
			var dog = f.Dog.Build();
			dog.RegisteredAt = null;
			dog.IsValid().Should(Be.False);

			dog.RegisteredAt = DateTime.Now;
			dog.IsValid().Should(Be.True);
		}

		[Test]
		public void requires_unique_id() {
			var dog = f.Dog.Build();
			dog.UniqueId = null;
			dog.IsValid().Should(Be.False);

			dog.UniqueId = Guid.NewGuid();
			dog.IsValid().Should(Be.True);
		}
	}
}
