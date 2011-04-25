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
			for (int i = 0; i < 3; i++)
				f.Dog.Create();
			Context.Dogs.Count().ShouldEqual(3);
		}

		[Test]
		public void requires_name() {
			var dog = f.Dog.Build(new { Name = f.Null });
			dog.IsValid().Should(Be.False);
			dog.ErrorMessagesFor("Name").ShouldContain("The Name field is required.");

			dog.Name = "Awesome Rover";
			dog.IsValid().Should(Be.True);
		}

		[Test]
		public void requires_name_to_be_awesome() {
			var dog = f.Dog.Build(new { Name = "Rover" });
			dog.IsValid().Should(Be.False);
			dog.ErrorMessagesFor("Name").ShouldContain("Name must be awesome!");

			dog.Name = "Awesome Rover";
			dog.IsValid().Should(Be.True);
		}

		[Test]
		public void requires_unique_name() {
			f.Dog.Create(new { Name = "Awesome Rover" }).IsValid().Should(Be.True);
			f.Dog.Create(new { Name = "Awesome Rover" }).IsValid().Should(Be.False); // <-- same name
			f.Dog.Create(new { Name = "Awesome Spot"  }).IsValid().Should(Be.True);
		}

		[Test]
		public void requires_breed() {
			f.Dog.Build(new { Breed = f.Null   }).IsValid().Should(Be.False);
			f.Dog.Build(new { Breed = "Beagle" }).IsValid().Should(Be.True);
		}

		[Test]
		public void requires_vet_id() {
			f.Dog.Build(new { VetId = f.Null }).IsValid().Should(Be.False);
			f.Dog.Build(new { VetId = 5      }).IsValid().Should(Be.True);
		}

		[Test]
		public void requires_registered_at() {
			f.Dog.Build(new { RegisteredAt = f.Null       }).IsValid().Should(Be.False);
			f.Dog.Build(new { RegisteredAt = DateTime.Now }).IsValid().Should(Be.True);
		}

		[Test]
		public void requires_unique_id() {
			f.Dog.Build(new { UniqueId = f.Null         }).IsValid().Should(Be.False);
			f.Dog.Build(new { UniqueId = Guid.NewGuid() }).IsValid().Should(Be.True);
		}
	}
}