using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrashcollectorProject.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name="First Name")]
        [StringLength(50, MinimumLength=1)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        public string FullName
        {
            get { return LastName + ", " + FirstName; }
        }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int ZipCode { get; set; }
        
        [Display(Name = "Pickup Day")]
        public string PickupDay { get; set; }

        public IEnumerable<SelectListItem> DayList { get; set; }

        [Display(Name = "Account Balance")]
        public double AccountBalance { get; set; }

        public string ExtraDay { get; set; }
    }
}