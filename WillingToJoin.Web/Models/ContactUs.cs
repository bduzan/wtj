using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WillingToJoin.Web.Models
{
    public class ContactUs
    {
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }	
    }
}