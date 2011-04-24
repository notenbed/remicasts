using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TestDrivenDogs.Specs {

	[SetUpFixture]
	public class SpecSetup {

		[SetUp]
		public void BeforeAll() {
			RefreshContext();
		}

		[TearDown]
		public void AfterAll() {}

		public static void TruncateAllTables() {
			MvcApplication.CurrentDogsContext.Database.ExecuteSqlCommand("DELETE FROM Dogs");
		}

		public static void RefreshContext() {
			MvcApplication.CurrentDogsContext = new DogsContext();
		}
	}

	public class WebSpec : Mara.MaraTest {

		public DogsContext Context { get; set; }

		[SetUp]
		public void BeforeEach() {
			SpecSetup.RefreshContext();
			SpecSetup.TruncateAllTables();
			Context       = MvcApplication.CurrentDogsContext;
			CurrentDriver = new Mara.Drivers.WebClient();
			Root          = "http://tdd-dogs";
		}

		[TearDown]
		public void AfterEach() {}
	}
}