using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FactoryMan.Generic;
using FactoryMan.Sequences;
using Model.IsValid;

namespace TestDrivenDogs.Specs {

	public class Factories {

		public object Null = (object) null;

		public static Sequence DogName = new Sequence(i => string.Format("Awesome Rover #{0}", i));

		public Factory<Dog> Dog = new Factory<Dog>().
			Add("Name",         d => DogName.Next()).
			Add("Breed",        "Golden Retriever").
			Add("VetId",        5).
			Add("RegisteredAt", DateTime.Now).
			Add("UniqueId",     Guid.NewGuid()).
			SetCreateAction(dog => {
				if (! dog.IsValid()) return;
				MvcApplication.CurrentDogsContext.Dogs.Add(dog);
				MvcApplication.CurrentDogsContext.SaveChanges();
			});
	}
}