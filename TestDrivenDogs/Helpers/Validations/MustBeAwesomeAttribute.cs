using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestDrivenDogs {
	public class MustBeAwesomeAttribute : ValidationAttribute {
		protected override ValidationResult IsValid(object value, ValidationContext context) {
			if (value != null && value.ToString().ToLower().Contains("awesome"))
				return ValidationResult.Success;
			else
				return new ValidationResult(
					string.Format("{0} must be awesome!", context.DisplayName), 
					new string[]{ context.DisplayName }
				);
		}
	}
}