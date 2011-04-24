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
		}
	}
}
