﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WillingToJoin.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "RoleName")]
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class EditUserViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        [Required(AllowEmptyStrings = false)]
        public string Phone { get; set; }


        public IEnumerable<SelectListItem> RolesList { get; set; }
    }
}