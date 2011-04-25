using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestDrivenDogs {
	public class Dog {

		public int Id { get; set; }

		[Required][MustBeAwesome][Unique]
		public string Name { get; set; }

		[Required]
		public string Breed { get; set; }

		[Required]
		public int? VetId { get; set; }

		[Required]
		public DateTime? RegisteredAt { get; set; }

		[Required]
		public Guid? UniqueId { get; set; }
	}
}