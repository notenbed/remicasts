using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Model.IsValid;

namespace TestDrivenDogs.Specs.Model {
	
	[TestFixture]
	public class DogSpec : ModelSpec {

		static int dogNameInt = 0;
		public static int NextInt {
			get { dogNameInt++; return dogNameInt; }
		}

		public static Dog ValidDog {
			get {
				return new Dog {
					Name  = string.Format("Awesome Rover #{0}", NextInt),
					Breed = "Golden Retriever",
					VetId = 5,
					RegisteredAt = DateTime.Now,
					UniqueId     = Guid.NewGuid()
				};
			}
		}

		[Test]
		public void can_create_valid_dogs() {
			Context.Dogs.Count().ShouldEqual(0);
			for (int i = 0; i < 3; i++) {
				var dog = ValidDog;
				Console.WriteLine("Creating dog ... there are {0} dogs", Context.Dogs.Count());
				Context.Dogs.Add(dog);
				Context.SaveChanges();
			}
			Context.Dogs.Count().ShouldEqual(3);
		}

		[Test]
		public void requires_name() {
			var dog = ValidDog;
			dog.Name = null;

			dog.IsValid().Should(Be.False);
			dog.ErrorMessagesFor("Name").ShouldContain("The Name field is required.");

			dog.Name = "Awesome Rover";
			dog.IsValid().Should(Be.True);
		}

		[Test]
		public void requires_name_to_be_awesome() {
			var dog = ValidDog;
			dog.Name = "Rover";

			dog.IsValid().Should(Be.False);
			dog.ErrorMessagesFor("Name").ShouldContain("Name must be awesome!");

			dog.Name = "Awesome Rover";
			dog.IsValid().Should(Be.True);
		}

		[Test]
		public void requires_unique_name() {
			var rover1 = ValidDog;
			rover1.Name = "Awesome Rover";
			Context.Dogs.Add(rover1);
			Context.SaveChanges();
			Context.Dogs.Count().ShouldEqual(1);

			var rover2 = ValidDog;
			rover2.Name = "Awesome Rover";
			rover2.IsValid().Should(Be.False);
			rover2.ErrorMessagesFor("Name").ShouldContain("Name already taken");

			var spot = ValidDog;
			spot.Name = "Awesome Spot";
			spot.IsValid().Should(Be.True);
		}

		[Test]
		public void requires_breed() {
			var dog = ValidDog;
			dog.Breed = null;
			dog.IsValid().Should(Be.False);

			dog.Breed = "Golden Retriever";
			dog.IsValid().Should(Be.True);
		}

		[Test]
		public void requires_vet_id() {
			var dog = ValidDog;
			dog.VetId = null;
			dog.IsValid().Should(Be.False);

			dog.VetId = 5;
			dog.IsValid().Should(Be.True);
		}

		[Test]
		public void requires_registered_at() {
			var dog = ValidDog;
			dog.RegisteredAt = null;
			dog.IsValid().Should(Be.False);

			dog.RegisteredAt = DateTime.Now;
			dog.IsValid().Should(Be.True);
		}

		[Test]
		public void requires_unique_id() {
			var dog = ValidDog;
			dog.UniqueId = null;
			dog.IsValid().Should(Be.False);

			dog.UniqueId = Guid.NewGuid();
			dog.IsValid().Should(Be.True);
		}
	}
}
