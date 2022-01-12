using System.ComponentModel.DataAnnotations;

namespace Quotes_API.Entity
{
    public class UserRoles
    {
        [Required]
        public string RoleName { get; set; }
    }
}