using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestDrivenDogs {
	public class UniqueAttribute : ValidationAttribute {
		protected override ValidationResult IsValid(object value, ValidationContext context) {
			if (context.ObjectType != typeof(Dog) || context.DisplayName != "Name")
				throw new Exception(string.Format("We don't know how to check for a unique {0} {1}", context.ObjectType, context.DisplayName));
		
			if (value == null) return ValidationResult.Success;

			var db   = MvcApplication.CurrentDogsContext;
			var dog  = context.ObjectInstance as Dog;
			var name = value.ToString();
			foreach (var hasSameName in db.Dogs.Where(d => d.Name == value))
				if (hasSameName.Id != dog.Id)
					return new ValidationResult("Name already taken", new string[]{ "Name" });
			return ValidationResult.Success;
		}
	}
}