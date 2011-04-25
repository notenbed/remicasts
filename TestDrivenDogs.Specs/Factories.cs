using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FactoryMan.Generic;
using FactoryMan.Sequences;

namespace TestDrivenDogs.Specs {

	public class Factories {

		public static Sequence DogName = new Sequence(i => string.Format("Awesome Rover #{0}", i));

		public Factory<Dog> Dog = new Factory<Dog>().
			Add("Name",         d => DogName.Next()).
			Add("Breed",        "Golden Retriever").
			Add("VetId",        5).
			Add("RegisteredAt", DateTime.Now).
			Add("UniqueId",     Guid.NewGuid());
	}
}