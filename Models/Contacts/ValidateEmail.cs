using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeAssign.Models.Contacts
{
    public class ValidateEmail : ValidationAttribute
    {
        private ContactContext db = new ContactContext();

        public ValidateEmail()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                bool contactExists = db.Contacts.Any(c => c.Email.Equals(value));

                if (contactExists)
                {
                    return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
                }
            }
            return null;
        }
    }
}