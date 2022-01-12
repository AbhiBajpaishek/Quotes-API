using System.ComponentModel.DataAnnotations;

namespace Quotes_API.Entity
{
    public class UserLogin
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } 
        [DataType(DataType.Password)]   
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}