using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestDrivenDogs {
	public class ValidateAttribute : ValidationAttribute {

		public ValidateAttribute(params Func<object, ValidationContext, ValidationResult>[] validations) {
			Validations = validations.ToList();
		}

		public IList<Func<object, ValidationContext, ValidationResult>> Validations { get; set; }

		protected override ValidationResult IsValid(object value, ValidationContext context) {
			foreach (var validation in Validations) {
				var result = validation(value, context);
				if (result != null && result != ValidationResult.Success)
					return result;
			}
			return ValidationResult.Success;
		}
	}
}