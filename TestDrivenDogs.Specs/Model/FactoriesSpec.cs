using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Model.IsValid;

namespace TestDrivenDogs.Specs.Model {
	
	[TestFixture]
	public class FactoriesSpec : ModelSpec {
		
		[Test]
		public void dog() {
			Context.Dogs.Count().ShouldEqual(0);
			for (int i = 0; i < 3; i++)
				f.Dog.Create().IsValid().Should(Be.True);
			Context.Dogs.Count().ShouldEqual(3);
		}
	}
}