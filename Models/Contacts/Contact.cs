using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeAssign.Models.Contacts
{
    public class Contact
    {
        public int ContactId { get; set; }

        [Required(ErrorMessage = "The field cannot be empty!")]
        [StringLength(20, ErrorMessage = "The {0} must be between {2} characters long and {1} characters long", MinimumLength = 1)]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "The field cannot be empty!")]
        [StringLength(20, ErrorMessage = "The {0} must be between {2} characters long and {1} characters long", MinimumLength = 1)]
        public String LastName { get; set; }

        [Required(ErrorMessage = "The field cannot be empty!")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email format is not valid.")]
 
        public String Email { get; set; }

        [Required(ErrorMessage = "The field cannot be empty!")]
        public String Address { get; set; }

        public int CityId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public City City { get; set; }
    }
}