using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WillingToJoin.Models
{
	public class ContactViewModel
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public int Type { get; set; }

		[Required]
		[EmailAddress(ErrorMessage = "Invalid Email Address")]
		public string Email { get; set; }

		[Required]
		public string Message { get; set; }

		public string PostMessage { get; set; }
	}
}