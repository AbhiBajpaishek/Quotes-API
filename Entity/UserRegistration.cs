using System.ComponentModel.DataAnnotations;
using Quotes_API.CustomValidations;

namespace Quotes_API.Entity
{
    public class UserRegistration
    {
        [Required]
        [EmailAddress]
        [CustomDomainValidation("nagarro.com", ErrorMessage = "Only nagarro.com is acceptable")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}