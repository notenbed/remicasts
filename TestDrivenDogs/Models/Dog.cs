﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestDrivenDogs {
	public class Dog {
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
	}
}