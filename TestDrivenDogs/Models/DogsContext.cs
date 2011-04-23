using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TestDrivenDogs {
	public class DogsContext : DbContext {
		public DbSet<Dog> Dogs { get; set; }
	}
}